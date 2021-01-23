    public class RequestA
    {
    }
    
    public class RequestB
    {
    }
    
    public class RequestC
    {
    }
    
    public class RequestProcesser :
    	IProcessRequest<RequestA>,
    	IProcessRequest<RequestB>,
    	IProcessRequest<RequestC>
    {
    	public void Process<RequestA>(RequestA request)
    	{
    	}
    	
    	public void Process<RequestB>(RequestB request)
    	{
    	}
    	
    	public void Process<RequestC>(RequestC request)
    	{
    	}
    }
    
    public interface IProcessRequest<TRequest>
    {
    	void Process<TRequest>(TRequest request);
    }
