    private static string conString = string.Empty;
    public static string SqlConnectionString()
    {
        if(conString == "")
           conString = string.Format("............");
        return conString;
    }
