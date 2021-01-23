    public class Item
    {
        public Item()
        {
            Children = new List<Item>();
        }
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int ParentId { get; set; }
        public List<Item> Children { get; set; } 
    }
    public class TreeBuilder
    {
        public TreeBuilder(IEnumerable<Item> items)
        {
            _items = new HashSet<Item>(items);
            TreeRootItems = new List<Item>();
            TreeRootItems.AddRange(_items.Where(x => x.ParentId == 0));
            BuildTree(TreeRootItems);
        }
        private readonly HashSet<Item> _items;
        public List<Item> TreeRootItems { get; private set; }
        public void BuildTree(List<Item> result)
        {
            foreach (var item in result)
            {
                item.Children.AddRange(_items.Where(x => x.ParentId == item.Id));
                BuildTree(item.Children);
            }
        }
    }
