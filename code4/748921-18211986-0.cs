    [ComVisible(true)] // may be optional depending on your other assembly settings
    public class ResultList
    {
        private List<Result> _innerList;
        internal ResultList(...parameters...)
        {
            _innerList = ...
        }
        public int Count
        {
            get
            {
                return _innerList.Count;
            }
        }
        public Result this[int index] // will be named "Item" in COM's world
        {
            get
            {
                return _innerList[index];
            }
        }
    }
