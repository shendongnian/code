    public static class ExtensionMethods {
	public static bool ContainsTag(this IWebElement element, string tagName)
	{
		string elementText = element.GetAttribute("innerHTML");
		return CheckStringForTag(elementText, tagName);
	}
	public static bool ContainsClass(this IWebElement element, string className)
	{
		string elementText = element.GetAttribute("innerHTML");
		return CheckStringForClass(elementText, className);
	}
	public static bool ContainsTag(this IWebDriver element, string tagName)
	{
		return CheckStringForTag(element.PageSource, tagName);
	}
	public static bool ContainsClass(this IWebDriver driver, string className)
	{
		return CheckStringForClass(driver.PageSource, className);
	}
	private static bool CheckStringForTag(string text, string tagName)
	{
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text.Contains("<" + tagName + ">") || text.Contains("</" + tagName + ">") || text.Contains("<" + tagName + " ");
		}
		return false;
	}
	private static bool CheckStringForClass(string text, string className)
	{
		if (!string.IsNullOrWhiteSpace(text))
		{
			string pattern = string.Format(".*class[\\s]?=[\\s]?.*[\\s'\"]{0}[\\s'\"].*.*", className);
			Match m = Regex.Match(text, className, RegexOptions.IgnoreCase);
			return m.Success;
		}
		return false;
	}
	public static string InnerHTML(this IWebElement element)
	{
		return element.GetAttribute("innerHTML");
	}}
