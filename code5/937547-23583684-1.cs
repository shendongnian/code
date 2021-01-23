    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
	
	public interface IUnitOfWork : IDisposable
	{
	    T GetRepository<T>();
		void Commit();
	}
	public class MyController
	{    
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;
	
		public MyController(IUnitOfWorkFactory unitOfWorkFactory)
		{
			_unitOfWorkFactory = unitOfWorkFactory;
		}
		
		public void RunTasks()
		{
			using (var unitOfWork = _unitOfWorkFactory.Create())
			{
				var rep = UnitOfWork.GetRepository<Tasks>();
				var newTasks = from t in rep.GetAll()
							   where t.IsCompleted == false
							   select t;
				foreach (var task in newTasks)
				{
					// Do something
				}				
				
				unitOfWork.Commit();
			}
		}
	}  
