	public interface IUnitOfWork<TContext> { }
	public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext> {
		private readonly TContext _context;
		protected TContext Context { get{ return _context; } }
		
		protected UnitOfWork(TContext context){
			_context = context;
		}
	}
	public interface IMyDbUnitOfWork : IUnitOfWork<MyContext>{
		
		public ICarRepository Cars { get; }
		public IOwnerRepository Owners { get; }
	}
	public class MyDbUnitOfWork : UnitOfWork<MyContext>, IMyDbUnitOfWork{
		public MyDbUnitOfWork():base(new MyContext()){}
		
		private ICarRepository _cars;
		public ICarRepository Cars { 
			get{
				return _cars ?? (_cars = new CarRepository(Context));
			}
		}
		
		private ICarRepository _owners;
		public IOwnerRepository Owners { 
			get{
				return _owners ?? (_owners = new OwnerRepository(Context));
			}
		}
	}
	public class MyService : IService
	{
		private readonly IMyDbUnitOfWork _unitOfWork;
		public MyService(IMyDbUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		//Methods...
	}
