    public class MyFactory : IMyFactory
    {
        private readonly Container container;
        public MyFactory(Containter container)
        {
            this.container = container;
        }
    }
