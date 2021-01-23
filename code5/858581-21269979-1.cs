    public class AutofacInstanceProvider : IInstanceProvider
    {
        // lots of code removed...
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            if (instanceContext == null)
            {
                throw new ArgumentNullException("instanceContext");
            }
            var extension = new AutofacInstanceContext(_rootLifetimeScope);
            instanceContext.Extensions.Add(extension);
            return extension.Resolve(_serviceData);
        }
    }
