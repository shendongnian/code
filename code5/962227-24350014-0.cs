    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {                      
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            if(e.Index == Convert.ToInt32(textBox1.Text))
            {
                g.FillRectangle(new SolidBrush(Color.Green), e.Bounds);
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }
            ListBox lb = (ListBox)sender;
            g.DrawString(listBox1.Items[e.Index].ToString(), e.Font,
                   new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
    }
       
