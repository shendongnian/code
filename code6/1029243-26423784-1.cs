    private void button2_Click(object sender, EventArgs e)
    {
            this.IsMdiContainer = true;
            InchMm_Conversion f = new InchMm_Conversion();
            f.MdiParent = this;
    //Here you set an event. When the form closes the here specified method is called 
            f.FormClosed += f_FormClosed; 
            f.Show();
            button2.Enabled = false;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        this.LayoutMdi(MdiLayout.ArrangeIcons);
    }       
    //This method is executed when the form is closed
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
               button2.Enabled = true;
        }
