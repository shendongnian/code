    class Node<T>
    {
        private T data;
    
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        private Node<T> link;
    
        internal Node<T> Link
        {
            get { return link; }
            set { link = value; }
        }
    
        public Node<T>(T p)
        {
            data = p; 
        }
    }
