    public class TreeNode : TreeRoot, ITreeChild
    {
        public string Name
        {
            get;
            set;
        }
        private object parent;
        public object Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        public TreeNode()
            : base()
        {
            Init();
        }
    }
