    public interface IMember
    {
        object MemberGenericID{get;}
    }
    public partial class MemberPurchases : IMember
    {
        object IMember.MemberGenericID
        {
            get { return MemberID; }
        }
    }
    public partial class MemberReturns : IMember
    {
        object IMember.MemberGenericID
        {
            get { return MemberID; }
        }   
    }
		
