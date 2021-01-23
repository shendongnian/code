    using (var dc = new DatabaseConnectionDataContext()){
    if (dc.Users.Any(o => o.Username== tbUsername.Text && o.Password == tbPassword.Text ...){
    ...
    }else{dc.AddNewUser(tbUsername.Text, tbPassword.Text, tbFirstname.Text, tbLastname.Text);}
    dc.SubmitChanges();
    }
