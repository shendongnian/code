    public void CreateConn()
    {
        if (constr.State == ConnectionState.Closed) 
        {
             constr.ConnectionString = ConfigurationManager.ConnectionStrings
                                        ["RegistrationConnectionStri‌​ng"].ConnectionString;
             constr.Open();
        }
    }
