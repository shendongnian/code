    abstract class CommunicationChannel<Client> : IDisposable where Client :  class, IDisposable
    {
        private Client client;
    	
    	protected TResult WithClient(Func<Client, TResult> f)
    	{
    		this.Open();
    		try {
    			return f(this.client);
    		}
    		catch(Exception) {
    			//cleanup
    		}
    	}
    	
    	protected void WithClient(Action<Client> act)
    	{
    		WithClient<object>(c => { act(c); return null; })
    	}
    }
