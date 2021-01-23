            protected void Application_Start()
        {
            //The culture value determines the results of culture-dependent functions, such as the date, number, and currency (NIS symbol)
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("he-il");
            //System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("he-il");
        }
