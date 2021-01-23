    class Node
    {
        private MusicCD data;
    
        public MusicCD Data
        {
            get { return data; }
            set { data = value; }
        }
        private Node link;
    
        internal Node Link
        {
            get { return link; }
            set { link = value; }
        }
    
        public Node(MusicCD d)
        {
            this.data = d;
        }
    }
