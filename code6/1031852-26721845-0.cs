        public class SearchItem : SearchResultItem
     {
        [IndexField("type")]
        public string Type{ get; set; }    
     }
    
     public class Search
     {
        public static IEnumberable<Item> GetItems()
        {
           List<Item> items = new List<Item>();
            var index = ContentSearchManager.GetIndex(new SitecoreIndexableItem(Sitecore.Context.Item));
            using (var context = index.CreateSearchContext())
            {
                var indexItems = context.GetQueryable<FRBSearchResultItem>()
                    .Where(x => !string.IsNullOrEmpty(x["type"]))
                    .OrderByDescending(x => x.ReleaseDate);
    
                foreach(var indexItem in indexItems)
                {
                    var tempItem = indexItem.GetItem();
                    items.Add(tempItem);
                }
            }
            return items;
        }
     }
