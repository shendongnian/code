    static ObjectContext New
    {
        get
        {
            return new ObjectContext(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString);
        }
    }
