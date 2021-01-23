    public class TestDataAccessClass
    {
    	public DataAccessClass Target { get; set; }
    
    	protected int Calls = 0;
    	protected DataEntities DE;
    
    	[SetUp]
    	public void before_each_test()
    	{
    		Target = new DataAccessClass(string.Empty);
    		Calls = 0;
    		FullAccessCalls = 0;
    
    		var fakeConnection = "metadata=res://*/bla.csdl|res://*/bla.ssdl|res://*/bla.msl;provider=System.Data.SqlClient";
    
    		DE = Effort.ObjectContextFactory.CreateTransient<DataEntities>(fakeConnection);
    		Target.DataAccessFactory = () => { Calls++; return DE; };
    		
    		SetupSomeTestData(DE);
    	}
    
    }
