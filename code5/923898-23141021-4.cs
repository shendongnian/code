    abstract class CommunicationChannel<Client> : IDisposable where Client :  class, IDisposable
    {
        private Client client;
    	
            protected TResult WithClient<TResult>(Func<Client, TResult> f)
            {
                this.Open();
                try
                {
                    return f(client);
                }
                catch (Exception)
                {
                    //cleanup
                }
                return default(TResult);
            }
    	
    	protected void WithClient(Action<Client> act)
    	{
    		WithClient<object>(c => { act(c); return null; })
    	}
    }
