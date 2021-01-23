    public class Widget
    {
        readonly IProviderFactory _factory;
        public Widget(IProviderFactory factory)
        {
            _factory = factory;
        }
        public Widget Create()
        {
            var provider = _factory.Create<IDataProvider>();
            provider.AddInput("name", "name");
            provider.AddInput("path", "path");
            provider.AddInput("dateCreated", DateTime.UtcNow);
            //.....
        }
    }
