        public class SwaggerConfig
        {
            public static void Register(HttpConfiguration config)
            {
                var thisAssembly = typeof(SwaggerConfig).Assembly;
        
                config
                     .EnableSwagger(c =>
                        {
                            ...                       
                            c.DocumentFilter<HideInDocsFilter>();
                            ...
                        })
                    .EnableSwaggerUi(c =>
                        {
                            ...
                        });
            }
        }
