    class MyClass
    {
        private readonly object _lock = new object();
        private readonly List<int> _myList = new List<int>();
        private int _index;
        
        public void MyOperation()
        {
            lock(_lock) 
            {
                _index++;
            }
        }
        public void MyOperation2()
        {
            lock(_lock) 
            {
                _myList[_index] = 27;
            }
        }
    }
