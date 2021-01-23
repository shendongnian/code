    public class Tree
    {
        private Branch[] branches = new Branch[100];
        ...
        public string Name { get; set; }
    
        public Branch this[int i]
        {
            get
            {
                return branches[i];
            }
        }
    }
