                //Find textbox control
                TextBox txtname = (TextBox)e.Row.FindControl("txtName");
                string Name = txtname.Text;
              
                if (((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString() == "Leave")
                { 
                    txtname.disable=true;
                }
                else 
                { 
                    txtname.disable = false; 
                }
            }
        }
   
    
