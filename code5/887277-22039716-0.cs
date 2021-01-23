    internal class Factory : IFactory {
        private readonly IResolutionRoot resolutionRoot;
        public Factory(IResolutionRoot resolutionRoot) {
            this.resolutionRoot = resolutionRoot;
        }
        T Create<T>() {
            return this.resolutionRoot.GetContextPreserving<T>();
        }
    }
