    public static string CheckLoginStatus()
    {
        string username = (string)System.Web.HttpContext.Current.Session["username"];
        string password = (string)System.Web.HttpContext.Current.Session["password"];
        if (username == "" || password == "")
            return "no";
        else if (DBAccess.GetDataSet("SELECT * FROM users WHERE username='" + username + "';").Tables[0].Rows.Count != 0)
        {
            DataRow row = DBAccess.GetDataSet("SELECT * FROM users WHERE username='" + username + "';").Tables[0].Rows[0];
            if (row["password"].ToString() == password)
            {
                if (row["admin"].ToString() == "True")
                    return "admin";
                else
                    return "user";
            }
            else
                return "no";
        }
        else
            return "no";
    }
