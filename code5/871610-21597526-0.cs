    protected void Modify_ItemCommand(object source, DataListCommandEventArgs e)
        {
     
            /* select the row index */
            int index = Convert.ToInt32(e.Item.ItemIndex);
     
            /*To get and Textbox of selected row*/
            TextBox txtbx = (TextBox)e.Item.FindControl("TextBox1");
     
            /* Assigning Value to your textbox */
            txtbx.Text = "What ever you want here";
     
        }
