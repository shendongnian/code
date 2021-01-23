    public class TreeItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<TreeItem> Children { get; set; }
        
        public void PrintAllChildren()
        { 
            this.PrintAllChildren(0);
        }
    
        private void PrintAllChildren(int indent)
        {
            Debug.WriteLine("{1}Item id: {0}", this.Id, string.Concat(Enumerable.Repeat<int>(0, indent).Select(i => " ")));
            if (this.Children != null)
                foreach (var item in this.Children)
                    item.PrintAllChildren(indent + 1);
        }
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
        private static TreeItem FillChildren(this TreeItem item, ILookup<int?, TreeItem> lookup)
        {
            item.Children = lookup[item.Id].Select(i => i.FillChildren(lookup));
            return item;
        }
    }
