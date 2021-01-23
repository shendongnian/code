    AccessorClass s = new AccessorClass ();    
    s.DB = txtDatabase.Text;
    s.ID = txtID.Text;
    s.Password = txtPassword.Text;
    HelperClass.Get(s); // <--- pass the instance through
