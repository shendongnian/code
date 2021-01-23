    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
		 // This line added to activate your binary formatter.
            config.Formatters.Add(new BinaryMediaTypeFormatter());
