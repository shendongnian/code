c#
public class NgByModelFinder : By
{
    public NgByModelFinder(string locator)
    {
        FindElementMethod = (ISearchContext context) => context.FindElement(NgBy.Model(locator));
    }
}
and then attach FindsBy attribute with your webelement like: 
c#
[FindsBy(How = How.Custom, Using = "value for locator", CustomFinderType = typeof(NgByModelFinder))]
protected IWebElement TestDiv { get; set; }
I hope the above will help you.
