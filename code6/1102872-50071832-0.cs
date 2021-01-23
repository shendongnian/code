            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "TestApiWithToken");
                c.ApiKey("Token")
                .Description("Filling bearer token here")
                .Name("Authorization")
                .In("header");
            })
            .EnableSwaggerUi(c =>
            {
                c.EnableApiKeySupport("Authorization", "header");
            });
