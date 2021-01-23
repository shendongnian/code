	public interface IQueryHelper
	{
		IList<MyObject> DoYourQuery(string value);
	}
	public class QueryHelper : IQueryHelper
	{
		readonly MyDbContext myDbContext;
		public QueryHelper(MyDbContext myDbContext)
		{
			this.myDbContext = myDbContext;
		}
		public IList<MyObject> DoYourQuery(string value)
		{
			return myDbContext.Database.SqlQuery<MyObject>("exec [dbo].[my_sproc] {0}", value).ToList();
		}
	}
