	public class NInjectKernel
	{
	  private readonly IKernel _kernel;
	  private NInjectKernel()
	  {
	    _kernel = new StandardKernel();
	  }
	  
	  private static volatile Irr2NInjectKernel _instance;
	  private static readonly object SyncRoot = new object();
	  public static Irr2NInjectKernel Instance
      {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            var temp = new Irr2NInjectKernel();
                            temp.BindAllDependencies();
                            _instance = temp;
                        }
                    }
                }
                return _instance;
            }
        }
		
		private void BindAllDependencies()
        {
			_kernel.Bind<IMyService>().To<MyService>();
            _kernel.Bind<IDALContract>().ToMethod(x =>
            {
                IParameter parameter = x.Parameters.SingleOrDefault(p => p.Name == "type");
                if (parameter != null)
                {
                    var recordType = (Discriminator)parameter.GetValue(x, x.Request.Target);
                    switch (recordType)
                    {
                        case RecordType.Animal:
                            return new DALAnimalsContract();
                        case RecordType.Person:
                            return new DALPeopleContract();
                        default:
                            throw new NotSupportedException("DQS type is not suppported.");
                    }
                }
                throw new NotSupportedException();
            });
		}
	}
