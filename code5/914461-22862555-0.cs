    public class HierarchicalLifetimeTaskDecorator : ITask
    {
        private readonly Container container;
        public HierarchicalLifetimeTaskDecorator(Container container) {
            this.container = container;
        }
        public void Execute() {
            using (var scope = container.CreateChildContainer()) {
                ITask realTask = scope.Resolve<ITask>();
                realTask.Execute();
            }
        }
    }
