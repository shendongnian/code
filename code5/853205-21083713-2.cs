    public class MyViewModel
    {
        public MyViewModel()
        {
            Children = new ObservableCollection<ChildViewModel>(GenerateChildren());
        }
        public ObservableCollection<ChildViewModel> Children { get; set; }
        private static IEnumerable<ChildViewModel> GenerateChildren()
        {
            return from value in Enumerable.Range(1, 1000)
                   select new ChildViewModel {Value = value};
        }
    }
    public class ChildViewModel
    {
        public int Value { get; set; }
    }
