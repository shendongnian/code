    var user = database1DataSet
                      .employee
                      .FirstOrDefault(r=> r.Username == userNameBox.Text &&
                                     r.Password == passwordBox.Text)
    if(user != null)
    {
        MessageBox.Show("Access granted welcome " + user.fName);
        this.Close();
    
    }
    else
    {
        MessageBox.Show("Invalid username/password");
    }
