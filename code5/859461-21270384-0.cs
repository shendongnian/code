    private void timer1_Tick(object sender, EventArgs e)
    {
        if (!this.TopMost == true)
            this.TopMost = true;
    
        this.Visible = true;
       
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    
        MessageBox.Show("Some error occured");
    }
