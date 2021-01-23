    private void Form1_Load(object sender, EventArgs e)
    {
        Assign(this);
    }
    void Assign(Control control)
    {
        foreach (Control ctrl in control.Controls)
        {
            if (ctrl is TextBox)
            {
                TextBox tb = (TextBox)ctrl;
                tb.TextChanged += new EventHandler(tb_TextChanged);
            }
            else
            {
                Assign(ctrl);
            }
        }
    }
    void tb_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        tb.Tag = "CHANGED"; // or whatever
    }
