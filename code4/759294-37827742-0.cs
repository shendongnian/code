    public class NgByModelFinder : By
    {
        public NgByModelFinder(string locator)
        {
            FindElementMethod = (ISearchContext context) => context.FindElement(NgBy.Model(locator));
        }
    }
