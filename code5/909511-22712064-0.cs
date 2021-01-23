        var userData = myDataContext.Users
            .Where(x=>x.UserName.Equals(userName)  
            && x.Password.Equals(passWord).FirstOrDefault();
        if (userData==null)
        {
          // there is no user with this username/password combo ...
        }
        else
        {
          if (userData.UserType=="admin")
              AdminLogin();
          else if (userData.UserType=="employee"
              EmployeeLogin();
        }
