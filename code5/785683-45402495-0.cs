    public static class Extensions
    {
    	public static async Task<TcpClient> AcceptTcpClientAsync(this TcpListener listener, CancellationToken token)
    	{
    		try
    		{
    			return await listener.AcceptTcpClientAsync();
    		}
    		catch (Exception ex) when (token.IsCancellationRequested) 
    		{ 
    			throw new OperationCanceledException("Cancellation was requested while awaiting TCP client connection.", ex);
    		}
    	}
    }
