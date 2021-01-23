    // this class exists only in your webapp
    public class SetLifestyleOnWebApp: ISetLifestyle
    {
        public BasedOnDescriptor SetLifestyle(BasedOnDescriptor descriptor)
        {
            return descriptor.LifestylePerWebRequest();
        }
    }
    
    // this class exists only in your windows service
    public class SetLifestyleOnService : ISetLifestyle
    {
        public BasedOnDescriptor SetLifestyle(BasedOnDescriptor descriptor)
        {
            return descriptor.LifestyleTransient(); // or whatever scope you need
        }
    }
