            int check = 0;
            foreach (RepeaterItem item in searchResultRepeater.Items)
            {
                TextBox txt = (TextBox)item.FindControl("yourTextBoxName");
                if (txt.Text == string.Empty)
                {
                    check = 0;
                }
                else
                {
                    check = 1;
                    break;
                }
            }
