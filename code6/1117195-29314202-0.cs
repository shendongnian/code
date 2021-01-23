     public static class CollectionsUtils
    {
        public static bool isPageIntegrable(this ModelItems modelItem)
        {
            int integrable = 0;
            bool result = Int32.TryParse(modelItem.Page,  out integrable);
            return result;
        }
    ....
