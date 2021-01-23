	public class KendoValueProviderFactory : ValueProviderFactory
	{
		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			return new KendoValueProvider(controllerContext.HttpContext.Request.QueryString);
		}
	}
