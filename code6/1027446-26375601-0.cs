    public class Repository
    {
        public Task<string> GetItem()
        {
            var serviceAgent = new ApiServiceAgent();
            // Don't need to do anything with the result of GetItem, just return the task.
            return serviceAgent.GetItem();
            //var apiResponse = await serviceAgent.GetItem();
            //For simplicity/brevity my domain object is a lowercase string
            //return apiResponse.ToLower(); 
        }
    }
