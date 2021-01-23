    if (inglist.SelectedIndex > -1 && rows > 0 && SelectedExist == false)
    {
                
        foreach (Control txt in mypanel.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
        {
            if (txt is TextBox && txt.Text == "")
            {
                txt.Text = CmpStr;
                break;
            }
            else
            {
                if (txt is TextBox && txt.Text == CmpStr)
                {
                    break;
                }
            }
        }
    }
        
