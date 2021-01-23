    public class MyController : Controller
    {
    	private readonly ICsvReader csv;
    
    	public MyController( ICsvReader csv )
    	{
    		this.csv = csv;
    	}
    }
    
    public class CsvReaderMock : ICsvReader
    {
    	public void Read()
    	{
    		throw new Exception();
    	}
    }
