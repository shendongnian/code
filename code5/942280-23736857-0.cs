    private void RadioButtonCheckedChanged(object sender, EventArgs e)
    {
        TabControl.TabPageCollection pages = tabControl1.TabPages;
        var rdoButtonName = sender as RadioButton;
        foreach (TabPage page in pages)
        {
            foreach (Control item in page.Controls)
            {
                if (item is RadioButton)
                {
                    if (item.Name != rdoButtonName.Name)
                    {
                        item.Checked = false;
                    }
                  
                }
            }
        }
    }
