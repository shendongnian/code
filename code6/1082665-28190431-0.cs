    [Route("/purchase/query")]
    public class QueryPurchase : QueryBase<Purchase>
    {
        public int Id { get; set; }
    }
    
    client.Get(new QueryPurchase { Id = 1 }).PrintDump();
