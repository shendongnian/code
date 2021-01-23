    // make the _connection string_ static, not the _connection_
    static string conDB = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
    [WebMethod, ScriptMethod]
    public static List<HomeImageSliders> GetHomeImageSliders()
    {
        List<HomeImageSliders> HomeImageList = new List<HomeImageSliders>();
        try
        {
            using (SqlConnection con = new SqlConnection(conDB)) error
            {
            }
