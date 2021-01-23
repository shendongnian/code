	public partial class YourDBContext : DbContext
	{
		public System.Data.Entity.Core.Objects.ObjectContext AsObjectContext()
		{
			return (this as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;
		}
		[DbFunction("YourDBModel.Store", "fn_PWDCOMPARE")]
		public bool fn_PWDCOMPARE(string pwd, string pwdhash)
		{
			var paramList = new ObjectParameter[]
			{
				new ObjectParameter("pwd", pwd),
				new ObjectParameter("pwdhash", pwdhash)
			};
			return this.AsObjectContext().CreateQuery<bool>("YourDBModel.Store.fn_PWDCOMPARE", paramList).Execute(MergeOption.NoTracking).FirstOrDefault();
		}
