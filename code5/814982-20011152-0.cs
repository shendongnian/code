    public void Form1()
    {
        InitializeComponent();
        pictureBox1.Paint += pictureBox1_Paint;
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.FillEllipse(Brushes.Red, pictureBox1.ClientRectangle);
    }
