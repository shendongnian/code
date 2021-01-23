    public class ServiceFactory
    {
        private readonly Container container;// = initialize the container
        public TService CreateService<TService>()
        {
            return container.GetInstance<TService>();
        }
    }
