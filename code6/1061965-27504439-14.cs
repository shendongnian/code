    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("http://www.example.com", "*", "*");
            config.EnableCors(cors);
            
            // ...
        }
    }
