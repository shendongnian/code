    public class Response
    {
        public bool Success { get; private set; }
        public static Response CreateErrorResponse()
        {
            return new Response { Success = false };
        }
    }
    public interface ICommand<T> where T : Response
    {
         Task<T> ExecuteAsync();
    }
    public abstract class CommandBase<T> : ICommand<T> where T: Response
    {
        protected abstract Uri BuildUrl();
        protected abstract Task<T> HandleResponseAsync();
        public async Task<T> ExecuteAsync()
	{
		var url = BuildUrl();
		var httpClient = new System.Net.Http.HttpClient();
	
		try
		{
			var response = await httpClient.GetAsync(url);
			return null;// await HandleResponseAsync(response);
		}
		catch (Exception hex)
		{
			return (T)Response.CreateErrorResponse(); // doesn't compile
		}
	}
    }
    public async override Task<T> ExecuteAsync()
    {
        var url = BuildUrl();
        var httpClient = new HttpClient();
        try
        {
            var response = await httpClient.GetAsync(url);
            return await HandleResponseAsync(response);
        }
        catch (HttpRequestException hex)
        {
            return (T)Response.CreateErrorResponse(); // compiles on liqpad
        }
    }
