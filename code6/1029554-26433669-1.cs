    public class MyHubActivator : IHubActivator
        {
            private readonly Container _container;
    
            public MyHubActivator(Container container)
            {
                _container = container;
            }
    
            public IHub Create(HubDescriptor descriptor)
            {
                return _container.GetInstance(descriptor.HubType) as IHub;
            }
        }
