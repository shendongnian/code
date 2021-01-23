    public class MyMongoRepository<T> : MongoRepository<T>
    {
        public MyMongoRepository() : base("connectionString", "name") { }
    }
    container.RegisterType(typeof(IRepository<>), typeof(MyMongoRepository<>));
