        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            foreach (ListItem myItem in DropDownList1.Items)
            {
                try
                {
                    if (myItem.Text.Length > 8)
                        myItem.Text = myItem.Text.Substring(0, 11) + "...";
                }
                catch (ArgumentOutOfRangeException ex) 
                { 
                    //do nothing
                }
            }
        }
