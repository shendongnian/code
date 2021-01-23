    public class Content
    {
        private Dictionary<string, string> contentItems;
        public string this[string key]
        {
            if (contentItems == null)
            {
                contentItems = contentItemList.ToDictionary(i => i.Key, i => i.Value);
            }
            if (contentItems.ContainsKey(key))
            {
                return contentItems[key];
            }
            return string.Empty;
        }
        //other properties
    }
