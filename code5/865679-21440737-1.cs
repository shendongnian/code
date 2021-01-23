    public Form()
    {
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
    }
    
    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Insert)
        {
            timer1.Stop();
        }
    }
