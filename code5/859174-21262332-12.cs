	public class MyValidationFeature : IPlugin
	{
		static readonly ILog Log = LogManager.GetLogger(typeof(MyValidationFeature));
		
		public void Register(IAppHost appHost)
		{
			// Registers to use your custom validation filter instead of the standard one.
			if(!appHost.RequestFilters.Contains(MyValidationFilters.RequestFilter))
				appHost.RequestFilters.Add(MyValidationFilters.RequestFilter);
		}
	}
	public static class MyValidationFilters
	{
		public static void RequestFilter(IHttpRequest req, IHttpResponse res, object requestDto)
		{
			// Determine if the Request DTO type has a MyRoleAttribute.
			// If it does not, run the validation normally. Otherwise defer doing that, it will happen after MyRoleAttribute.
			if(!requestDto.GetType().HasAttribute<MyRoleAttribute>()){
				Console.WriteLine("Running Validation");
				ValidationFilters.RequestFilter(req, res, requestDto);
				return;
			}
			Console.WriteLine("Deferring Validation until Roles are checked");
		}
	}
