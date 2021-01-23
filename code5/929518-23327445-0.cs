    public class MyForm : Form
    {
        //way 1
        private void MyForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("my text");
        }
        //way 2
        private Bitmap b;
    
        private void MyForm_Load(object sender, EventArgs e)
        {
            b = new Bitmap(1366; 768);
            Graphics g = Graphics.FromImage(b);
            Brush br;
            g.DrawString("my text", new Font("Arial", 12), br, 0, 0);
            g.Dispose();
            Invalidate();
        }
    
        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(b, 0, 0);
        }
    }
