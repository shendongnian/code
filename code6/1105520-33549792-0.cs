        public static void Register(HttpConfiguration config)
        {
            ...
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "My API Title");
                    c.IncludeXmlComments(GetXmlCommentsFileLocation());
                })
                .EnableSwaggerUi();
            ...
        }
 
        private static string GetXmlCommentsFileLocation()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\bin";
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFileLocation = Path.Combine(baseDirectory, commentsFileName);
            return commentsFileLocation;
        }
