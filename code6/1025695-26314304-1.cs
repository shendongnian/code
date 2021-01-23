            public static string makeConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["MyDb.Properties.Settings.ConString"].ToString();
            return con;
        }
