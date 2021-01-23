    public static class StyleExtension 
    {
        public static void AddExisting(this CssStyleCollection collection, 
            CssStyleCollection existing)
        {
            foreach (string item in existing.Keys)
            {
                collection.Add(item, existing[item]);
            }
        }
    }
