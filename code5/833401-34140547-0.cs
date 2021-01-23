    foreach (Control c in Controls.OfType<CheckBox>())
                {
                    if (((CheckBox)c).Checked == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
