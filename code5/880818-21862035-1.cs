    internal class NinjectCustomConverter<T> : CustomCreationConverter<T> where T : class
    {
        private readonly IResolutionRoot _serviceLocator;
        public NinjectCustomConverter(IResolutionRoot serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        public override T Create(Type objectType)
        {
            return _serviceLocator.Get(objectType) as T;
        }
    }
