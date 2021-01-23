    public class SomeFactory : ISomeFactory
    {
        private readonly IResolutionRoot resolutionRoot;
        public SomeFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public ISomething Create(string parameter1)
        {
            this.resolutionRoot.Get<ISomething>(new ConstructorArgument("parameter1", parameter1);
        }
    }
