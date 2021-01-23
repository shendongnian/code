    public class MyMongoRepository<T> : MongoRepository<T>
    {
        // of course you should fill in the real connection string here.
        public MyMongoRepository() : base("connectionString", "name") { }
    }
    container.RegisterType(typeof(IRepository<>), typeof(MyMongoRepository<>));
