    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        private IResolutionRoot resolutionRoot { get; set; }
        public BusinessEngineFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        T IBusinessEngineFactory.GetBusinessEngine<T>()
        {
            return this.resolutionRoot.Get<T>();
        }
    }
