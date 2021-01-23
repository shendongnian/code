    //user chooses database, let's say they do this on a page
    Session["Database"]=GetUserDatabaseSelection();
    
    //now somewhere else, we'll connect to the database specified by their Session.
    public void connect()
    {
        string ConnString="";
        switch(Session["Database"])
        {
            case "Tienda": ConnString="Data Source=APPLE01;DataBase=Tienda;User ID=sa;Password=Ases0r1a;"; break;
            case "OtherDB": ConnString="Data Source=APPLE01;DataBase=OtherDB;User ID=sa;Password=myotherpass;"; break;
            default: throw new ApplicationException("Unknown database");
        }
        Connection = new System.Data.SqlClient.SqlConnection(ConnString);
        Connection.Open();
    }
