    public class TreeModel
    {
        public TreeModel Parent { get; set; }
        public HierarchicalObservableCollection<TreeModel, TreeModel> Children { get; set; }
        public TreeModel()
        {
            Children = new HierarchicalObservableCollection<TreeModel, TreeModel>(this, (i, p) => i.Parent = p);
        }
    }
