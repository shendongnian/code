    [Route("/cims/qcHistoryByLot/{lotNumber*}", "GET")]
    public class GetQcHistoryByLot
    {
        public string LotNumber { get; set; }
    }
