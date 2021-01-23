        public void Configuration(IAppBuilder app)
        {
            var configuration = WebApiConfiguration.HttpConfiguration;
            app.Map("/api", inner =>
            {
                inner.UseWebApi(configuration);
            });
        }
