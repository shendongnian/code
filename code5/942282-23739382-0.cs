    private void RadioButtonCheckedChanged(object sender, EventArgs e)
    {
        TabControl.TabPageCollection pages = tabControl1.TabPages;
        var rdoButtonName = sender as RadioButton;
        // Disable all other RadioButtons
        foreach (TabPage page in pages)
        {
             foreach (Control item in page.Controls)
            {
                if (item is RadioButton)
                {
                    if (item != rdoButtonName) { item.Checked = false; }
                }
            }
        }
    }
