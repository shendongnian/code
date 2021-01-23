    {
        get
        {
            try
            {
                if (_instance == null)
                {
                    _instance = ConfigurationManager.GetSection("Admin") as AdminSection;   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _instance;
        }
    }
