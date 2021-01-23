    private void Odeslat_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        button2.Enabled = false;
        Thread thread = new Thread(Process);
        thread.IsBackground = true;
        thread.Start();        
    }
