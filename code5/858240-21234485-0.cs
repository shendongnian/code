    public class FactoryB : IFactoryB {
        private readonly IResolutionRoot resolutionRoot;
        public FactoryB(IResolutionRoot resolutionRoot) {
            this.resolutionRoot = resolutionRoot;
        }
        public IClassB Create(int paramA, int paramB) {
            return this.resolutionRoot.Get<IClassB>(new ConstructorArgument("paramA", paramA), new ConstructorArgument("paramB", paramB));
        }
    }
