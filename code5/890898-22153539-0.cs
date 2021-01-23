	using System.Web.Security;
	using SecurityGuard.Services;
	namespace MyMembershipNamespace
	{
		public class MyMembershipService : MembershipService
		{
			public MyMembershipService(MembershipProvider membershipProvider)
			: base(membershipProvider)
			{
			}
			public MembershipUser CreateUser(string username, string password, string email, string company, string phone)
			{
				//Add code here to save company and phone to the database
				//allow base to execute normally
				return base.CreateUser(username, password, email);
			}
		}
	}
