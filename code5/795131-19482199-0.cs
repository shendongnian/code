    public partial class Form1 : Form
    {
        public class TextData
        {
            public string Text;
            public string FontName;
            public int FontSize;
            public RectangleF TextRectF;
            public Color TextColor;
        }
        private List<TextData> Texts = new List<TextData>();
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
            TextData td = new TextData();
            td.Text = "Example";
            td.FontName = "Courier";
            td.FontSize = 24;
            td.TextRectF = new RectangleF(50.0F, 50.0F, 175.0F, 75.0F);
            td.TextColor = Color.Red;
            Texts.Add(td);
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (TextData td in Texts)
            {
                using (Pen drawPen = new Pen(td.TextColor))
                {
                    e.Graphics.DrawRectangle(drawPen, Rectangle.Round(td.TextRectF));
                }
                using (Font drawFont = new Font(td.FontName, td.FontSize))
                {
                    using (SolidBrush drawBrush = new SolidBrush(td.TextColor))
                    {
                        e.Graphics.DrawString(td.Text, drawFont, drawBrush, td.TextRectF);            
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextData td = new TextData();
            td.Text = "Sample Text";
            td.FontName = "Arial";
            td.FontSize = 16;
            td.TextRectF = new RectangleF(150.0F, 150.0F, 200.0F, 50.0F);
            td.TextColor = Color.Black;
            Texts.Add(td);
            this.Refresh();
        }
    }
