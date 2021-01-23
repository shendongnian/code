    public interface IMember
    {
        int MemberID { get; set; }
    }
    public class MemberPurchases : IMember
    {
        public int MemberID { get; set; }
        public string SomeProperty { get; set; }
    }
    public class MemberReturns : IMember
    {
        public int MemberID { get; set; }
        public string AnotherProperty { get; set; }
    }
