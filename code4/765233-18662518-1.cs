     class SampleList<T>
    {       
        private readonly List<T> _myList;
        public SampleList(List<T> myList)
         {
             _myList = myList;
         }
        public void Add(T items)
        {
            _myList.Add(items);
        }
    }
