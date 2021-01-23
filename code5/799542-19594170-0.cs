	public class SeleniumElement : IWrapsElement
	{
		private IWebElement cachedElement;
		private By mechanismUsed;
		public SeleniumElement(IWebElement element, By locatorUsed)
		{
			mechanismUsed = locatorUsed;
			cachedElement = element;
		}
		public IWebElement WrappedElement
		{
			get
			{
				return cachedElement;
			}
		}
	}
