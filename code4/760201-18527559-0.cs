    for (int i = 1; i < 12; i++)
                {
                    CheckBox cb = (CheckBox)Page.FindControl("Checkbox" + i);
                    cb.Enabled = false;
                    i = i + 2;
                }
