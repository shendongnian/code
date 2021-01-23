    class GenericList<T> where T : IComparable<T> // <-- this is the type constraint: only allow types that implement IComparable<T>
    {
        private List<T> _list = new List<T>();
        public void Add(T element)
        {
            // code for Add
        }
	
        public T Maximum()
        {
             // code for Maximum
        }
	
        public T Minimum()
        {
            // code for minimum
        }
    }
