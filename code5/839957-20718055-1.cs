    foreach (Control c in Panel1.Controls)
                {
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).Checked = false;
                    }
                    else if (c is TextBox)
                    {
                        ((TextBox)c).Text="";
                    }
                }
