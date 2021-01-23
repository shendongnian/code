    foreach (Control ctrl in form1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Text = string.Empty;
                }
                else if (ctrl is DropDownList)
                {
                    DropDownList dl = (DropDownList)ctrl;
                    dl.SelectedIndex = 0;
                }
                else if (ctrl is CheckBox)
                {
                    CheckBox cb = (CheckBox)ctrl;
                    cb.Checked = false;
                }
            }
