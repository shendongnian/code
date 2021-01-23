    public class MyRoleAttribute : RequestFilterAttribute
	{
		readonly string[] _roles;
		public MyRoleAttribute(params string[] roles)
		{
			_roles = roles;
		}
		#region implemented abstract members of RequestFilterAttribute
		public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
		{
			Console.WriteLine("Checking for required role");
			// Replace with your actual role checking code
			var role = req.GetParam("role");
			if(role == null || !_roles.Contains(role))
				throw HttpError.Unauthorized("You don't have the correct role");
			Console.WriteLine("Has required role");
			// Perform the deferred validation
			Console.WriteLine("Running Validation");
			ValidationFilters.RequestFilter(req, res, requestDto);
		}
		#endregion
	}
