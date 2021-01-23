    public ExampleService : IExampleService 
    {
        public Task<string> GetUsernameAsync() 
        {
           var name = System.Threading.Thread.CurrentPrincipal.Name;
           return Task.FromResult(name);
        }
    }
