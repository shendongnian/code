    struct lbo
    {
        // make the structure immutable
        public readonly Control ctl;
        // a simple constructor
        public lbo(Control ctl_) { ctl = ctl_; }
        // make it show the Name in the ListBox
        public override string ToString() { return ctl.Name; }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        // add a control:
        listBox1.Items.Add(new lbo(button1));
    }
    private void button2_Click(object sender, EventArgs e)
    {
        // to use it you will need to cast it to the correct control type!!
        ((lbo)listBox1.SelectedItem).ctl.Text = button2.Text;
    }
