    class TestAPI
    {
        APIClient API;
        public TestAPI(APIClient APIClient)
        {
            this.API = APIClient;
        }
    
        public Task<T> ExecuteAsync<T>()
    	{
    		var client = new RestClient();
    		var taskCompletionSource = new TaskCompletionSource<T>();
            RestRequest request = new RestRequest("TestCall", Method.POST);
    		
    		OpenRequest obj = new OpenRequest
            {
                User = userId,
                PIN = PIN
            };
    
            request.AddObject(obj);
    		try
    		{
    			client.ExecuteAsync<T>(request, (response) => taskCompletionSource.SetResult(response.Data));
    		}
    		catch (Exception e)
    		{
    			taskCompletionSource.SetException(e);
    		}
    		
    		return taskCompletionSource.Task;
    	}
    }
