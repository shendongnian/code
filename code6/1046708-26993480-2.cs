    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!globalHotKey.Unregister())
        {
            Application.Exit();
        }
    }
