    public class EodSettlementRequestStubData : IEnumerable<SettlementRequest>
    {
    
        public SettlementRequest UnapprovedFlows;
        public SettlementRequest UnapprovedRecovery;
        public SettlementRequest UnverifiedFlows;
        public SettlementRequest UnverifiedRecovery;
    
        public IEnumerator<SettlementRequest> GetEnumerator()
        {
            yield return UnapprovedFlows;
            yield return UnapprovedRecovery;
            yield return UnverifiedFlows;
            yield return UnverifiedRecovery;
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            //This is calling "IEnumerator<SettlementRequest> GetEnumerator()"
            return GetEnumerator();
        }
    }
