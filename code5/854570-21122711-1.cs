        public static class ContainerManager
        {
            private static IWindsorContainer _container = null;
            public static IWindsorContainer Container
            {
                 get {
                     if (_container == null) {
                          // run installers, set _container = new container
                     }
                     return _container;
                 }
    
            }
        }
