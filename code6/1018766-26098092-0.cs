    public class RouteResult : TableEntity
    {
        public string Session
        {
            get
            {
                return PartitionKey;
            }
            set
            {
                RowKey = value + "-" + DateTime.UtcNow.Ticks; // The issue is here
                PartitionKey = value;
            }
        }
    }
