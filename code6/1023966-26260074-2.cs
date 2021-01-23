    public static class BusinessLayerBootstrapper
    {
        public static void Bootstrap(Container container, ScopedLifestyle scopedLifestyle)
        {
            container.Register<IUnitOfWork, MyDbContext>(scopedLifestyle);
            // etc...
        }
    }
