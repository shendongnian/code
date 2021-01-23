    public class EntityContextFactory : IEntityContextFactory
    {
        private readonly Uri _someEndpoint = new Uri("http://somwhere.com");
        public IEntityContext CreateEntityContext()
        {
            // Code that creates the context.
            // If it's complex, pull it from your bootstrap or wherever else you've got it right now.
            return new EntityContext(_someEndpoint);
        }
    }
