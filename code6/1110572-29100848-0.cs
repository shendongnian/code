    public class TreeItem
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public IEnumerable<TreeItem> Children { get; set; }
    }
    
    public static class TreeItemExtension
    {
        public static IEnumerable<TreeItem> GetAsTree(this IEnumerable<TreeItem> data)
        {
            var lookup = data.ToLookup(i => i.ParentId);
            return lookup[null].Select(i => {
                i.Children = lookup[i.Id];
                return i;
            });
        }
    }
