    private void addEvents(Control.ControlCollection ct)
    {
        foreach (Control ctrl in ct)
        {
            if (ctrl is TextBox)
            {
                TextBox tb = (TextBox)ctrl;
                tb.TextChanged += new EventHandler(tb_TextChanged);
            }
            else if (ctrl is GroupBox || ctrl is Panel) addEvents(ctrl.Controls);
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        addEvents(this.Controls);
    }
    void tb_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        tb.Tag = "CHANGED"; // or whatever
    }
