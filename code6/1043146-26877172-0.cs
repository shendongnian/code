     public interface IRequestProcessorFactory
    {
    	IRequestProcessor GetProcessor(string action);
    }
    
    public class FactoryVersion1 : IRequestProcessorFactory
    {
    	public IRequestProcessor GetProcessor(string action)
    	{
    		switch(action)
    		{
    			case "m1":
    				return new M1Ver1RequestProcessor();
    			case "m2":
    				return new M2Ver1RequestProcessor();
    			case "m3":
    				return new M3Ver1RequestProcessor();
    			default:
    				throw new NotSupportedException();
    		}
    	}
    }
    
    public class FactoryVersion2 : IRequestProcessorFactory
    {
    	public IRequestProcessor GetProcessor(string action)
    	{
    		switch(action)
    		{
    			case "m1":
    				return new M1Ver2RequestProcessor();
    			case "m2":
    				return new M2Ver2RequestProcessor();
    			case "m3":
    				return new M3Ver2RequestProcessor();
    			default:
    				throw new NotSupportedException();
    		}
    	}
    }
    
    public interface IRequestProcessor
    {
    	string ProcessRequest(string message);
    }
    
    public class RequestProcessorBase<T>
    {
    	public string ProcessRequest(string message)
    	{
    		T result = Process(message);
    		string serializedResult = Serialize(result);
    		return ConvertToB64(serializedResult);
    	}
    	
    	protected abstract T Process(string message);
    	
    	private string Serialize(T result)
    	{
    		//Serialize
    	}
    	
    	private string ConvertToB64(string serializedResult)
    	{
    		//Convert
    	}
    }
    
    public class M1Ver1RequestProcessor : RequestProcessorBase<ResultObject1>
    {
    	protected ResultObject1 Process(string message)
    	{
    		//processing
    	}
    }
    
    public class M2Ver1RequestProcessor : RequestProcessorBase<ResultObject2>
    {
    	protected ResultObject2 Process(string message)
    	{
    		//processing
    	}
    }
    
    public class M3Ver1RequestProcessor : RequestProcessorBase<ResultObject3>
    {
    	protected ResultObject3 Process(string message)
    	{
    		//processing
    	}
    }
    
    public class M1Ver2RequestProcessor : RequestProcessorBase<ResultObject1>
    {
    	protected ResultObject1 Process(string message)
    	{
    		//processing
    	}
    }
    
    public class M2Ver2RequestProcessor : RequestProcessorBase<ResultObject2>
    {
    	protected ResultObject2 Process(string message)
    	{
    		//processing
    	}
    }
    
    public class M3Ver2RequestProcessor : RequestProcessorBase<ResultObject3>
    {
    	protected ResultObject3 Process(string message)
    	{
    		//processing
    	}
    }
