    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Size sz = new Size(300, 150);
            TriButton btn = new TriButton(sz, textBox1.Text, textBox2.Text, dateTimePicker1.Value);
            flowLayoutPanel1.Controls.Add(btn);
        }
    }
    public class TriButton : Button
    {
        private String ID;
        private String Information;
        private DateTime Date;
        public TriButton(Size initialSize, String ID, String Information, DateTime Date)
        {
            this.ID = ID;
            this.Information = Information;
            this.Date = Date;
            this.Size = initialSize;
            this.SizeChanged += TriButton_SizeChanged;
            this.CreateBackgroundImage();
            this.Text = "";
            this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackgroundImageLayout = ImageLayout.None;
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
        }
        private void TriButton_SizeChanged(object sender, EventArgs e)
        {
            this.CreateBackgroundImage();
        }
        private void CreateBackgroundImage()
        {
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Rectangle A = new Rectangle(new Point(0, 0), new Size(this.ClientRectangle.Width / 3, this.ClientRectangle.Height));
            Rectangle B = new Rectangle(new Point(A.Right, 0), new Size(this.ClientRectangle.Width - A.Width, this.ClientRectangle.Height / 2));
            Rectangle C = new Rectangle(new Point(A.Right, B.Bottom), new Size(B.Width, B.Height));
            using(Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(this.BackColor);
                using (Pen p = new Pen(SystemColors.ActiveBorder))
                {
                    g.DrawRectangle(p, A);
                    g.DrawRectangle(p, B);
                    g.DrawRectangle(p, C);
                }
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                using (Brush b = new SolidBrush(this.ForeColor))
                {
                    g.DrawString(this.ID, this.Font, b, A, sf);
                    g.DrawString(this.Information, this.Font, b, B, sf);
                    g.DrawString(this.Date.ToShortDateString(), this.Font, b, C, sf);
                }  
            }
            this.BackgroundImage = bmp;
        }
    }
