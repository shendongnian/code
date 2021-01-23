	void Main()
	{
		using(var dal = new DataAccessLayer())
		{
			var items = dal.TablesDtoQuery.Case1().Case2().ToList();
		}
	}
	public class DataAccessLayer : IDisposable
	{
		private DbContext context;
		
		public void Dispose()
		{
			context.Dispose();
		}
	
		public IQueryable<TablesDto> TablesDtoQuery
		{
			get
			{
				return 
					from table1 in context.TableOne
					join table2 in context.TableTwo on table1.SomeFKId equals table2.Id
					join table3 in context.TableThree on table2.SomeFKId equals table3.Id
					...
					join tableN in context.TableN on tableN_1.SomeFKId equals tableN.Id
					where case1 && case2 && case3 ... && caseN
					select new TablesDto { VarOne = table1.Var , VarTwo = tableN_2.var };
			}
		}
	}
	
	public static class TablesDtoQueryExtension
	{
		public IQueryable<TablesDto> Case1(this IQueryable<TablesDto> query)
		{
			return from t in query
				where ...
				select t;
		}
		
		public IQueryable<TablesDto> Case2(this IQueryable<TablesDto> query)
		{
			return from t in query
				where ...
				select t;
		} 
	}
