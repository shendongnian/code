    public class UserSpecificCustomerRepository : ICustomerRepository{
     private User _user;
     private ICustomerRepository _customerRepository;
     public UserSpecificCustomerRepository(User user, ICustomerRepository repo){
       _user = user;
       _customerRepository = repo;
     }
     public Customer Get(Expression<Func<Customer, bool>> where){
       where = where.And(x => x.GroupId == _user.GroupId);
      
      _customerRepository.Get(where);
     }
    }
