	public class Repository
	{
		private readonly string _connectionString;
		public Repository(string connectionString)
		{
			_connectionString = connectionString;
		}
		protected T GetConnection<T>(Func<IDbConnection, T> getData)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				return getData(connection);
			}
		}
		protected TResult GetConnection<TRead, TResult>(Func<IDbConnection, TRead> getData, Func<TRead, TResult> process)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				var data = getData(connection);
				return process(data);
			}
		}
	}
