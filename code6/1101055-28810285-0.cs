    public System.Windows.Forms.Form MyChild
    panel1.Visible = true;
    Form2 f2 = new Form2();
    f2.MyParent = this;
    this.MyChild = f2;
    -------
    -------
    f2.Show();
