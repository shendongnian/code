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
        // to just change the _Name (or Text or other properties present in all Controls)
        ((lbo)listBox1.SelectedItem).ctl.Text = button2.Text;
        // to use it as a certain Control you need to cast it to the correct control type!!
        ((Button)((lbo)listBox1.SelectedItem).ctl).FlatStyle = yourStyle;
    }
