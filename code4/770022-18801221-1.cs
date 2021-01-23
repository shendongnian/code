    public class PricingHandlerFactory
    {
        public PricingHandlerFactory(IContainer container)
        {
            _container = container;
        }
    
        public PricingHandler Create(string type)
        {
             var instance = ObjectFactory.TryGetInstance<PricingHandler>(type);
             return instance ?? ObjectFactory.GetInstance<PricingHandler>();
        }
    }
