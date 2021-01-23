    using MyInfrastructureAssembly.Interfaces;
    public MyApp: App // MyNewPlatFormApp
    {
	public override Initiaze()
	{
		var bootsrapper =  new Boostrapper(MyIoC.Current);
	}
    }
    public class Bootsrapper: TheBootStrapperOfMyIoc
    { 
       public Bootsrapper(IocContainer container)
       {
		Container = container;
       }
       public override Register()
       {
         Container.Register<IMyAbstractedService,MyPlatformDependantService>();   
       }
    } 
    MyPlatformDependantService : IMyAbstractedService 
    {
	public object Get(); // IMyAbstractedService.Get()
    }
    public class MyViewModel:ViewModelBase
    {
	IMyService  MyService {get;set;}
	MyViewModel(IMyAbstractedService myServcice)
	{		
		MyService = myService;
	}
	public object Thing // LazyThing provided by IMyAbstractedService 
	{
		get
		{ 
			if(_thing!=null)
			return _thing;
			return _thing = GetIt();
		}
		set 
		{
			if(Equals(value,_thing)) return;
			_thing = value;
			base.NotifyMagicalChanges()
		}
	}
        public void GetIt()
	{		
		MyServcie.Get();
	}
    }
