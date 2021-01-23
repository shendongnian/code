    Pen pen = new Pen(Color.Red);
 
    private void Form1_Load(object sender, System.EventArgs e)
    {
        pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
        
        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
    }
    private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        
        g.DrawLine(pen, 0, 0, pictureBox1.Right, 0);
        g.DrawLine(pen, 0, 0, 0, pictureBox1.Bottom);
    }
