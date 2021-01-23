    //user chooses database
    Session["Database"]=GetUserDatabaseSelection();
    
    public void connect()
    {
        string ConnString="";
        //now let's create the connection to the database somewhere else
        switch(Session["Database"])
        {
            case "Tienda": ConnString="Data Source=APPLE01;DataBase=Tienda;User ID=sa;Password=Ases0r1a;"; break;
            case "OtherDB": ConnString="Data Source=APPLE01;DataBase=OtherDB;User ID=sa;Password=myotherpass;"; break;
            default: throw new ApplicationException("Unknown database");
        }
        Connection = new System.Data.SqlClient.SqlConnection(ConnString);
        Connection.Open();
    }
