    private void Form1_Load(object sender, EventArgs e)
    {
        this.FormClosing += Form1_FormClosing;
    }
    
    void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.WindowsShutDown)
        {
            e.Cancel = true;
        }
    }
