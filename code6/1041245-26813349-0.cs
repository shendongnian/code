    public interface IMember
    {
        int MemberID { get; set; }
    }
    public class MemberPurchases : IMember
    {
        public int MemberID { get; set; }
        //...
    }
    public class MemberReturn : IMember
    {
        public int MemberID { get; set; }
        //...
    }
