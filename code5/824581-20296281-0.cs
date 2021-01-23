        [DataContract]
    public class ScalarResult
    {
        [DataMember(Order = 0)]
        public string QueryId { get; set; }
        [DataMember(Order = 1)]
        public float CurrentPeriodValue { get; set; }
        [DataMember(Order = 2)]
        public bool HasPriorValue { get; set; }
        [DataMember(Order = 3)]
        public float PriorPeriodValue { get; set; }
        [DataMember(Order = 4)]
        public float ChangeOverPrior { get; set; }
        [DataMember(Order = 5)]
        public float ChangeOverPriorPercent { get; set; }
        // rest of code here
        }
