    public void connect()
        {
            string ConnString = string.format("Data Source=APPLE01;DataBase={0};User ID=sa;Password=Ases0r1a;", Session["Database"]);
            Connection = new System.Data.SqlClient.SqlConnection(ConnString);
            Connection.Open();
        }
