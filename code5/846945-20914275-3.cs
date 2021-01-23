    Form3 obj3 = new Form3();
    private void button1_Click(object sender, EventArgs e)
    {
        if (obj3 != null && obj3.Visible) { obj3.Focus(); return; }
        obj3 = new Form3();
        obj3.Show(this);            
    }
