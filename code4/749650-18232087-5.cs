    class MyBaseCollection : IEnumerable<MyBase>
    {
        private List<MyBase> innerCollection;
        ....
        public void DisposeItems()
        {
           // call Dispose on each item here
        }
    }
