    public class CategoryCounts
    {
        private int _categoryCount;
        public int CategoryCount
        {
            [DebuggerStepThrough]
            get { return _categoryCount; }
            [DebuggerStepThrough]
            set
            {
                if (value != _categoryCount)
                {
                    _categoryCount = value;
                    OnPropertyChanged("CategoryCount");
                }
            }
        }
        private string _categoryName;
        public string CategoryName
        {
            [DebuggerStepThrough]
            get { return _categoryName; }
            [DebuggerStepThrough]
            set
            {
                if (value != _categoryName)
                {
                    _categoryName = value;
                    OnPropertyChanged("CategoryName");
                }
            }
        }
}
