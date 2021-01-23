    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        timer1.Stop();
    }
    private void Form1_Shown(object sender, EventArgs e)
    {
        timer1.Start();
    }
    void timer1_Tick(object sender, EventArgs e)
    {
        // All that will be left here is whatever you were executing in the
        // anonymous method you invoked. All that other stuff goes away.
        ...
    }
