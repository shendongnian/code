    public class Throw : RequestFieldValidatorBase
	{
		public Throw(string errorMessage)
			: base(errorMessage)
		{ }
		protected override bool IsValid(System.Web.HttpContextBase httpContext, string value)
		{
			return false;
		}
	}
