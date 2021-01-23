    public interface IDfsService
    {
        string Locale { get; set; }
        string DfsServiceUrl { get; set; }
        string UserName { get; set; }
    }
    public interface IDataPackageService : IDfsService
    {
        DataPackage GetObjectsWithContent()
    }
    public interface IFooService : IDfsService
    {
        Foo GetFoo();
        void DoSomethingWithFoo();
    }
