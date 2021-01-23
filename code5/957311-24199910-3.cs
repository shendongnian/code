    public void RunConsumer(BlockingCollection<SocketAsyncEventArgs> collection, int consumerId)
    {
    	Task.Run( async () =>
    	{
    		Console.WriteLine("Consumer {0} waiting", consumerId);
    		
    		SocketAsyncEventArgs args = null;
    		try
    		{
    		    args = collection.Take();
    			Console.WriteLine("Consumer {0} processing", consumerId);
    			await Task.Delay(5000);
    		}
    		catch(ObjectDisposedException)
    		{
    		   Console.WriteLine("Consumer {0} collection has been disposed", consumerId);
    		}
    		catch(InvalidOperationException)
    		{
    		   Console.WriteLine("Consumer {0} collection has been closed", consumerId);
    		}
    		finally
    		{
    		    // add the item back if collection hasn't been closed.
    			if(args != null && !collection.IsAddingCompleted)
    				collection.Add(args);
    		}
    		
    		Console.WriteLine("Consumer {0} finished", consumerId);
    	});
    }
