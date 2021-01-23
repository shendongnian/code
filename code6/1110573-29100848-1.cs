    public class TreeItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<TreeItem> Children { get; set; }
    }
    
    public static class TreeItemExtension
    {
        public static IEnumerable<TreeItem> GetAsTree(this IEnumerable<TreeItem> data)
        {
            var lookup = data.ToLookup(i => i.ParentId);
            return lookup[null].Select(i => {
                i.FillChildren(lookup);
                return i;
            });
        }
        private static void FillChildren(this TreeItem item, ILookup<int?, TreeItem> lookup)
        {
            item.Children = lookup[item.Id].Select(i => {
                i.FillChildren(lookup);
                return i;
            });
        }
    }
