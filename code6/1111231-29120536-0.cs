    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < DynamicPlaceHolder.Controls.Count; i++)
        {
            Control ctrl = DynamicPlaceHolder.Controls[i];
            if (ctrl is CheckBox)
            {
                CheckBox chk = (CheckBox)ctrl;
                chk.CheckedChanged += new EventHandler(cbTest_CheckedChanged);
            }
        }
    }
