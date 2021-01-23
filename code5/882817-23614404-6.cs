    public class MyNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            // Register the custom/additional processors/matchers for our view
            // rendering within the SSVE
            container
                .Register<IEnumerable<ISuperSimpleViewEngineMatcher>>(
                    (c, p) =>
                    {
                        return new List<ISuperSimpleViewEngineMatcher>()
                        {
                            // This matcher provides support for @Translate. tokens
                            new TranslateTokenViewEngineMatcher()
                        };
                    });
        }
        ...
