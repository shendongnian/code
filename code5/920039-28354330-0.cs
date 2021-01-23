    public abstract class BaseRepository
    {
	    private readonly string _ConnectionString;
	    protected BaseRepository(string connectionString)
	    {
		    _ConnectionString = connectionString;
	    }
 
	    // use for buffered queries
	    protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
	    {
		    try
		    {
			    using (var connection = new SqlConnection(_ConnectionString))
			    {
				    await connection.OpenAsync();
				    return await getData(connection);
			    }
		    }
		    catch (TimeoutException ex)
		    {
			    throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
		    }
		    catch (SqlException ex)
		    {
			    throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
		    }
	    }
 
	    // use for non-buffeed queries
	    protected async Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData, Func<TRead, Task<TResult>> process)
	    {
		    try
		    {
			    using (var connection = new SqlConnection(_ConnectionString))
			    {
				    await connection.OpenAsync();
				    var data = await getData(connection);
				    return await process(data);
			    }
		    }
		    catch (TimeoutException ex)
		    {
			    throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
		    }
		    catch (SqlException ex)
		    {
			    throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
		    }
	    }
    }
