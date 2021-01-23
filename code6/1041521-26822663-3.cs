    public class TenantDependencyProxy : IDependency {
        private readonly Containt container;
        private readonly ITenantContext context;
        
        public TenantDependencyProxy(Container container, ITenantContext context) {
            this.container = container;
            this.context = context;
        }
        
        object IDependency.DependencyMethod(int x) {
            return this.GetTenantDependency().DependencyMethod(x);
        }
        
        private IDependency GetTenantDependency() {
            switch (this.context.TenantId) {
                case "abc": return this.container.GetInstance<Tenant1Dependency>();
                default: return this.container.GetInstance<Tenant2Dependency>();
            }
        }
    }
