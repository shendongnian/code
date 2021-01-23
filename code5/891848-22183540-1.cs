        public class ListViewModel : INotifyPropertyChanged
    {
        private readonly IEnumerable<string> _originalList = new[] {"Groceries", "Test"};
        private IEnumerable<string> _dependentList;
        private int _originalListSelectedIndex;
        public IEnumerable<string> OriginalList
        {
            get { return _originalList; }
        }
        public IEnumerable<string> DependentList
        {
            get { return _dependentList; }
            set
            {
                _dependentList = value;
                OnPropertyChanged();
            }
        }
        public int OriginalListSelectedIndex
        {
            get { return _originalListSelectedIndex; }
            set
            {
                _originalListSelectedIndex = value;
                //Logic for changing dependent list goes here
                if (_originalListSelectedIndex == 0)
                {
                    DependentList = new[] { "Bread", "Milk", "Cheese", "Fruit" };
                }
                else
                {
                    DependentList = new[] { "test 1", "test 2" };
                }
            }
        }
    }
