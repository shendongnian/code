    if (queryResult.size > 0)
    {               
        for (int i = 0; i < queryResult.size; i++)
        {                    
             User user = (User)queryResult.records[i];
              id = user.Id;
              firstName = user.FirstName;
              lastName = user.LastName;
              role = user.UserRole.Name;
              string[] uSers = { id, firstName, lastName, role };
             listEdit.AddRange(uSers);
             // adds Items in uSers to lstEditUser
             lstEditUser.Items.Add(string.Format("{0}  {1} {2}   {3}", uSers));      
             lstDeleteUser.Items.Add(string.Format("{0}  {1} {2}       {3}",uSers));     
        }
	lstEditUser.SelectedIndexChanged += SelectNewUser;
	lstEditUser.SelectedIndex = 0;
        MessageBox.Show("The query result has found " + queryResult.size  + " users.");
    }
    private void SelectNewUser (object sender, EventArgs e)
    {
    	int idx = lstEditUser.SelectedIndex;
    	if (idx < 0)
    		return;
    	lblUserID.Text = listEdit[idx*4];
    }
