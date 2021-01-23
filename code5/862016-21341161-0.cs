    // Form1:
    void Button1Click(object sender, EventArgs e)
    {
        Form2 f2=new Form2();
        this.Hide();
        f2.Show(this);
    }
    
    // Form2:
    void Form2Load(object sender, EventArgs e)
    {
        if (this.Owner==null) throw new ArgumentException("This window must be called with the Owner property set!");
        // or just ignore, or show a MessageBox and close, or use your imagination...
    }
    
    void Form2FormClosed(object sender, FormClosedEventArgs e)
    {
        // sanity check...
        if (this.Owner!=null && !this.Owner.Visible) this.Owner.Show();
    }
