namespace WinFormsAppGraph
{
    public partial class Form1 : Form
    {
        private Button buttonDraw;
        private PictureBox pictureBox;
        private Label[] heightLabels;

        public Form1()
        {
            InitializeComponent();
            heightLabels = new Label[4];
            for (int i = 0; i < heightLabels.Length; i++)
            {
                heightLabels[i] = new Label();
                heightLabels[i].Location = new Point(10 + 100 * i, 350);
                heightLabels[i].AutoSize = true;
                Controls.Add(heightLabels[i]);
            }
            // ������� ������
            buttonDraw = new Button();
            buttonDraw.Text = "���������� ������";
            buttonDraw.Location = new Point(10, 10);
            buttonDraw.Click += buttonDraw_Click;
            Controls.Add(buttonDraw);

            // ������� PictureBox
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(10, 40);
            pictureBox.Size = new Size(400, 200); // ������� �������, ������� ��� �����
            Controls.Add(pictureBox);
            // ���������� ������ ����� ��� �����
            
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            // ���������� ������ � ��������
            float[] heights = { 8.25f, 4.1f, 2.72f, 2.43f };

            // ������� ����� Bitmap ��� ���������
            Bitmap graphBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphGraphics = Graphics.FromImage(graphBitmap);

            // ������� PictureBox
            graphGraphics.Clear(Color.White);

            // ���������� �������������� � �����
            Rectangle[] rectangles = new Rectangle[]
            {
                new Rectangle(pictureBox.Width / 2 - 3, pictureBox.Height  - (int)(8.25 * 10), 100, (int)(8.25 * 10)),
                new Rectangle(pictureBox.Width / 2 + 64, pictureBox.Height  - (int)(4.1 * 10), 50, (int)(4.1 * 10)),
                new Rectangle(pictureBox.Width / 2 + 48, pictureBox.Height  - (int)(2.72 * 10), 40, (int)(2.72 * 10)),
                new Rectangle((int)(pictureBox.Width / 2 - 7.2), pictureBox.Height - (int)(2.43 * 10), 40, (int)(2.43 * 10))
            };

            Color[] colors = { Color.Orange, Color.Green, Color.Red, Color.Blue };

            // ������ ��������������
            for (int i = 0; i < rectangles.Length; i++)
            {
                Rectangle rect = rectangles[i];
                Color color = colors[i];

                                // ��������� ����� � �������
                heightLabels[i].Text = $"{heights[i]}";
                heightLabels[i].Location = new Point(rect.Right - 30, rect.Top + 20);
                heightLabels[i].Size = new Size(rect.Width, rect.Height);
                graphGraphics.FillRectangle(new SolidBrush(color), rect);

            }

            // ���������� ����������� � PictureBox
            pictureBox.Image = graphBitmap;
        }
    }
}



