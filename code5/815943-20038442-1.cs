    public class Bootstrap {
        public IKernel Init() {
            return new StandardKernel(new NinjectModule[] {
                new YourModule(),
                new YourOtherModule()
            });
        }
    }
