    class MobilityScore : Score { }
    class SocialScore : Score { }
    class FunctionScore : Score { }
    class CognitionScore : Score { }
    class Score 
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
