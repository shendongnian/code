       private void CreateEmployee()
        {
            using (var db = new TidrapportDBEntities())
            {
                var user = (from p
                           in db.Login
                            where p.username != null
                            select p).ToList();
    
                bool found = false;
                foreach (var vUser in user)
                {
                    if (vUser.username == textBoxUsername.Text)
                    {
                        found = true;
                        labelSuccessFail.Visible = true;
                        labelSuccessFail.Text = "Accountname already exist.";
    
                        break;
                    }
               }
          
               if(!found)     
               {
                        var userInfo = new Login();
                        var persInfo = new PersonalInformation();
    
                        persInfo.firstname = textBoxFirstname.Text;
                        persInfo.lastname = textBoxLastname.Text;
    
                        userInfo.username = textBoxUsername.Text;
                        userInfo.password = textBoxPassword.Text;
                        userInfo.employeeId = persInfo.employeeId;
    
                        db.Login.Add(userInfo);
                        db.PersonalInformation.Add(persInfo);
                        db.SaveChanges();
