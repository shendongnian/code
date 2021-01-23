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
                        rdoButtonName.CheckedChanged -= new System.EventHandler(this.RadioButtonCheckedChanged);
                        if (rdoButtonName.Name == item.Name)
                        {
                            rdoButtonName.Checked = true;
                        }
                        else
                        {
                            rdoButtonName.Checked = false;
                        }
                        rdoButtonName.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
                    }
                }
            }
        }
