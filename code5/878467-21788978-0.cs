    public static
    { // Set a breakpoint here, and see what value is assigned to cfg.
        var cfg = ConfigurationManager.ConnectionStrings["DDB"];
        strCn = cfg.ConnectionString;
    }
