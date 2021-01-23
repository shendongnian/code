    Private static void CheckValues(TextBox t)
    {
      if(!string.IsnullOrEmpty(t.Text.Trim())
      {
          return t.Text;
      }
    }
    
      protected void Button2_Click(object sender, EventArgs e)
        {
                user.Title =CheckValues(txtTitle.Text);
           
                user.Forename = CheckValues(txtFirstName.Text);
           
                user.Surname = CheckValues(txtSurname.Text);
           
                user.Username = CheckValues(txtUsername.Text);
           
                user.Address1 = CheckValues(txtAddress.Text);
            
                user.Address2 = CheckValues(txtAddress.Text);
           
                user.PostCode = CheckValues(txtPostcode.Text);
          
                user.CountryCode = CheckValues(txtCode.Text);
            
                user.Email = CheckValues(txtEmail.Text);
           if(CheckValues(txtDate.Text))
            {
               DateTime _entrydate;
               if (DateTime.TryParse(txtDate.Text, out _entrydate))
                {
                    user.EntryDate = _entrydate;
                }
            }
           bool result = userDao.SaveNewUser(user);
           if (result)
           {
              Response.Redirect("~/User/List/somepage"); //~ for root directory , if there is any page use that or use the exact url here.
           }
    }
