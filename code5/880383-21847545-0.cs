    public interface IRepository<TEntity> where TEntity: class {
    	// Your methods
    }
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class {
    	public GenericRepository<TEntity>(EquipmentEntities  context) {
    		// Your constructor
    	}
    	
    	// Your implementation
    }
    
    public interface IUnitOfWork : IDisposable {
    	IRepository<Role> RoleRepository { get; }
    	IRepository<Storage> StorageRepository { get; }
    	// etc
    	
    	void Save();
    }
    
    public class UnitOfWork : IUnitOfWork {
    	public UnitOfWork () {
    		if (factory == null)
    			throw new ArgumentNullException("factory");
    	
    		this.context = new EquipmentEntities ();
    	}
    	
    	private EquipmentEntities context = null;
    
    	private IRepository<Role> roleRepository;
    	public IRepository<Role> RoleRepository { 
    		get {
    			if (this.roleRepository == null) {
    				this.roleRepository = new GenericRepository<Role>(context);
    			}
    			return this.roleRepository;
    		}
    	}
    	
    	// etc... other repositories
    	// etc... your implementation for Save and Dispose
    }
