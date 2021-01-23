     // two generic types
     // TDTO - view model type
     // TDomain - domain type
     public abstract class AbstractViewModelService<TDTO, TDomain> : IViewModelService
     {
         private UnitOfWork _uow { get; }        
         public AbstractViewModelService( UnitOfWork uow )
         {
             this._uow = uow;
         }
         public abstract IRepository<TDomain> Repository { get; }
         public TDTO GetSingle<TDTO>(int key)
         {
             // Get appropriate repository based on T1?
             // it is here ->
 
             return Mapper.DynamicMap<TDTO>( this.Repository.Find( key ) );
         }
     }
     public class UserViewModelService : AbstractViewModelService<UserDto, User> 
     {
         public override IRepository<User> Repository
         {
             get
             {
                 return this._uow.UserRepository;
             }
         }
         ...
     }
     public class AccountViewModelService : AbstractViewModelService<AccountDto, Account> 
     {
         public override IRepository<Account> Repository
         {
             get
             {
                 return this._uow.AccountRepository;
             }
         }
         ...
     }
