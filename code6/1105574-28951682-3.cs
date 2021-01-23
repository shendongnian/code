    public class Alt
    {
        public Member Member { get; set; }
        public Claim OriginalClaim { get; set; }
        public Claim AltClaim { get; set; }
        public double Savings { get; set; }
    }
    public class Claim
    {
        public int Id { get; set; }
    }
    public class Member
    {
        public int Id { get; set; }
    }
    public class Alternative
    {
        public Member Member { get; set; }
        public Claim OriginalClaim { get; set; }
        public List<AlternativeClaim> AlternativeClaims { get; set; }
    }
    public class AlternativeClaim
    {
        public Claim AltClaim { get; set; }
        public double Savings { get; set; }
    }
