    public class ItemHierarchy : Tuple<Item, int, List<ItemHierarchy>>
    {
        public static List<ItemHierarchy> BuildHierarchy(IEnumerable<Item> items)
        {
            var inputOrderNumbered = items.Select((item, order) => Tuple.Create(item, order));
            var roots = inputOrderNumbered.Where(i => !items.Any(n => n.nextID == i.Item1.ID));
            return roots.Select(r => BuildFor(r.Item1, r.Item2, inputOrderNumbered.Except(roots))).ToList();
        }
        public Item Item 
        { 
            get { return this.Item1; } 
        }
        public int OriginalInputOrder
        {
            get { return this.Item2; }
        }
        public int NumberOfDescendents
        {
            get { return this.Item3.Count + this.Item3.Sum(i => i.NumberOfDescendents); }
        }
        public IEnumerable<Item> Flattened
        {
            get { return new[] { this.Item }.Concat(Descendents); }
        }
        public List<ItemHierarchy> DescendentHierarchy
        {
            get { return this.Item3; }
        }
        public IEnumerable<Item> Descendents
        {
            get { return this.Item3.SelectMany(i => new [] { i.Item }.Concat(i.Descendents)); }
        }
        public IEnumerable<Item> Leafs
        {
            get
            {
                if (NumberOfDescendents == 0)
                    return new[] { this.Item };
                else
                    return DescendentHierarchy.SelectMany(d => d.Leafs);
            }
        }
        protected ItemHierarchy(Item item, int originalOrder, IEnumerable<Tuple<Item, int>> descendents, IEnumerable<Tuple<Item, int>> remaining)
            : base(item, originalOrder, descendents.Select(d => BuildFor(d.Item1, d.Item2, remaining)).ToList())
        {
        }
        private static ItemHierarchy BuildFor(Item item, int originalOrder, IEnumerable<Tuple<Item, int>> numberedSiblings)
        {
            var descendents = numberedSiblings.Where(s => s.Item1.ID == item.nextID);
            return new ItemHierarchy(item, originalOrder, descendents, numberedSiblings.Except(descendents));
        }
    }
