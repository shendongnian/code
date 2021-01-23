    public Form1()
    {
        InitializeComponent();
        oldColor = button1.BackColor;
    }
    Color oldColor;
    Color newColor = Color.FromArgb(0, Color.MediumAquamarine);  // your pick, including Black
    int alpha = 0;
    
    private void button1_MouseEnter(object sender, EventArgs e)
    {
        alpha = 0;
        timer1.Interval = 15;
        timer1.Start();
    }
    
    private void button1_MouseLeave(object sender, EventArgs e)
    {
        timer1.Stop();
        button1.BackColor =  oldColor;
        button1.ForeColor = Color.Black;
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        alpha += 17;  // change this for greater or less speed
        button1.BackColor = Color.FromArgb(alpha, newColor);
        if (alpha >= 255) timer1.Stop();
        if (button1.BackColor.GetBrightness() < 0.3) button1.ForeColor = Color.White;
    }
