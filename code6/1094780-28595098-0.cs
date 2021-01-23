    void InitContext() {
        
        String actualConnectionString = ConfigurationManager.ConnectionStrings["server123"].ConnectionString;
        
        String efConnectionString = String.Format(CultureInfo.InvariantCulture, "metadata=res://*/..;provider connection string={0};.", actualConnectionString);
        
        _context = new MyEFContext( efConnectionString );
    }
