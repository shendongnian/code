    // Connect to database through entity framework db context.
    public interface IMyService
    {
        MyDbContext DbContext { get; set; }
        IQueryable<Something> GetSomething( ... query params ... );
        void CreateSomething(Something model);
        // etc. 
    }
