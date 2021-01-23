    internal class ApiControllerConventions : CompositeCustomization
    {
        internal ApiControllerConventions()
            : base(
                new HttpRequestMessageCustomization(),
                new ApiControllerCustomization(),
                new AutoMoqCustomization())
        {
        }
    }
