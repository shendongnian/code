    [Route("/computer/{ComputerId}", "POST")]
    public class UpdateComputerRequest : IReturnVoid
    {
        public int LocationId { get; set; }
        public int ComputerId { get; set; }
    }
    [Route("/computer/{ComputerId}", "DELETE")]
    public class DeleteComputerRequest : IReturnVoid
    {
        public int ComputerId { get; set; }
    }
    
    [Route("/computers", "POST")]
    public class BatchRequest : IReturnVoid
    {
        public List<UpdateComputerRequest> UpdateRequests { get; set; }
        public List<DeleteComputerRequest> DeleteRequests { get; set; }
    }
    public class ComputerLocationService : Service
    {
        public void Post(UpdateComputerRequest request)
        {
            PostImpl(request);
        }
        public void Post(DeleteComputerRequest request)
        {
            DeleteImpl(request);
        }
        public void Post(BatchRequest request)
        {
            request.UpdateRequests.ForEach(PostImpl);
            request.DeleteRequests.ForEach(DeleteImpl);
        }
        private void PostImpl(UpdateComputerRequest request)
        {
            // do stuff...
        }
        private void DeleteImpl(DeleteComputerRequest deleteComputerRequest)
        {
            // delete
        }
    }
