public static List<string> GetElementAttributes(this RemoteWebDriver driver, IWebElement element)
{
    IJavaScriptExecutor ex = driver;
    var attributesAndValues = (Dictionary<string, object>)ex.ExecuteScript("var items = { }; for (index = 0; index < arguments[0].attributes.length; ++index) { items[arguments[0].attributes[index].name] = arguments[0].attributes[index].value }; return items;", element);
    var attributes = attributesAndValues.Keys.ToList();
    return attributes;
}
