	public interface IHttpContextFactory
	{
		HttpContextBase Create();
	}
	public class HttpContextFactory
		: IHttpContextFactory
	{
		public HttpContextBase Create()
		{
			return new HttpContextWrapper(HttpContext.Current);
		}
	}
