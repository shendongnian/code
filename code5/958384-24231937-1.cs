        public partial class Form1 : Form
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            bool canInvalidate = false;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                canInvalidate = true;
                Invalidate();
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                if (canInvalidate)
                {
                    float x = 20, y = 50;
                    int chosen = int.Parse(textBox1.Text);
                    foreach (var item in numbers)
                    {
                        int result = chosen * item;
                        e.Graphics.DrawString(string.Format("{0} * {1} = {2}", chosen, item, result), Font, Brushes.Black, x, y);
                        y += 10;
                    }
                }
            }
    
            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!(char.IsDigit(e.KeyChar)|| e.KeyChar == (char)Keys.Back))
                    e.Handled = true;
            }
        }
