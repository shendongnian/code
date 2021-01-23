    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Frm2 frm=new Frm2();
            frm.RefToForm1=this; // you said RefToForm1 isn't static and it shouldn't be
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
        }
    }
    private void textBox2_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            this.RefToForm1.textBox1.Text=textBox2.Text;
            this.Close(); // missing semicolon
        }
    }
    public Form1 RefToForm1 { get; set; } // property in Frm2
