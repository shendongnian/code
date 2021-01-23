    public class RouteResult : TableEntity
    {
        public RouteResult(string sessionId)
        {
            RowKey = sessionId + "-" + Guid.NewGuid();
            PartitionKey = sessionId;
        }
        public RouteResult()
        {
        }
    }
