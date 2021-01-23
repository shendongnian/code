    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            var myXmlCacheInstance = ... // read your xml file and create an object to hold it
            container.Register<MyXmlCahce>(myXmlCacheInstance);
        }
    }
