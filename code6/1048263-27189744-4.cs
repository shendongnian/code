            // Create DI container
            var builder = new ContainerBuilder();
            // Register application modules
            Autofac_RegisterApplicationModules(builder);
            // Register filter provider
            //builder.RegisterFilterProvider();
            // Register MVC specific abstractions (HttpRequestBase,HttpResponceBase etc)
            builder.RegisterModule(new AutofacWebTypesModule());
            // container
            var container = builder.Build();
