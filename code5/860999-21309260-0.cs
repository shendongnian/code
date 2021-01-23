          protected void txtData_TextChanged(object sender, EventArgs e)
            {
               if(txtData.Text == "something")
               {
                   btnSave.Enabled = True;
               }
               else
                   btnSave.Enabled = False;
            }
