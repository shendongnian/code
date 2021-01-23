    async Task<int> SomeAsyncWork()
    		{
    			await Task.Delay(1000);
    			throw new WebException("This is fake");
    			return 1; // Unreachable!!
    		}
