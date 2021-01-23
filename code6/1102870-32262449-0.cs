    httpConfiguration
        .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
        .EnableSwaggerUi(c =>
            {
                c.CustomAsset("index", yourAssembly, "YourWebApiProject.SwaggerExtensions.index.html");
            });
