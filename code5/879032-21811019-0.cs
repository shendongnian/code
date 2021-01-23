    // Update a location with single computer
    [Route("/Location/{LocationId}", "POST")]
    public class UpdateLocationRequest : IReturnVoid
    {
        public int LocationId { get; set; }
        public int ComputerId { get; set; }
    }
    // Update a location with multiple computers
    [Route("/Location/{LocationId}/Multiple", "POST")]
    public class UpdateMultipleLocationsRequest : IReturnVoid
    {
        public int LocationId { get; set; }
        public int[] ComputerIds { get; set; }
    }    
    public class ComputerLocationService : Service
    {
        public void Post(UpdateLocationRequest request)
        {
            UpdateLocation(request.LocationId, request.ComputerId);
        }
        public void Post(UpdateMultipleLocationsRequest request)
        {
            // Multiple computers updated by calling the handler many times.
            foreach(int computerId in request.ComputerIds)
                UpdateLocation(request.LocationId, computerId);
        }
        // Method for handling updating one location
        private void UpdateLocation(int locationId, int computerId)
        {
            // Logic to perform the update
        }
    }
