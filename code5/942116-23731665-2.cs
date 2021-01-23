     if (dr.HasRows)
     {
           dr.Read();
           int userType = Convert.ToInt32(dr["U_Type"]);
           if (userType == 1)
           {
               MessageBox.Show("Login Successful");
               MDIParent1 settingsForm = new MDIParent1();
               settingsForm.Show();
               this.Hide();
           }
           else if (userType == 2)
           {
               MessageBox.Show("Login Successful");
               MDIParent2 settingsForm = new MDIParent2();
               settingsForm.Show();
               this.Hide();
           } 
           Program.sCurrentUserName = dr["U_Name"].ToString(); //assumption U_Name
      }
      else
      {
            Program.sCurrentUserName = string.Empty;
            //other code
      }
