    // A nested type to exaggerate the fact that this is inside your Composition Root
    private sealed class NinjectItemProcessorFactory : IItemProcessorFactory {
        private readonly Kernel kernel;
        public NinjectItemProcessorFactory(Kernel kernel) {
            this.kernel = kernel;
        }
        public IItemProcessor GetProcessor(ItemProcessorType type) {
            this.kernel.Get<IItemProcessor>(type.ToString());
        }
    }
