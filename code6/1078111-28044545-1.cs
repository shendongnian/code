    public class CustomerMongoRepository : MongoRepository<Customer>, ICustomerRepository
    {
    ....
    }
    Bind<ICustomerRepository>().To<CustomerMongoRepository>()
    .Named("Customer")
    .WithConstructorArgument(kernel.TryGet<MongoDatabase>());
