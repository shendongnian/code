    public partial class Form1 : Form
            {
            public Form1()
                {
                InitializeComponent();
                }
    
            private void Form1_Load(object sender, EventArgs e)
                {
    
                }
            protected override void OnPaint(PaintEventArgs e)
                {
                base.OnPaint(e);
                MeasureStringMin(e);
                }
            private void MeasureStringMin(PaintEventArgs e)
                {
    
                // Set up string. 
                string measureString = "MEASURE STRING";
                Font stringFont = new Font("Arial", 16);
    
                // Measure string.
                SizeF stringSize = new SizeF();
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
    
                // Draw rectangle representing size of string.
                e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);
    
                // Draw string to screen.
                e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0));
                }
            }
