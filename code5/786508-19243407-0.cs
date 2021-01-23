    public class Outer
    {
        public ObservableCollection<int> InnerItems { get; set; }
        public bool HasItems  // <<< Add bool property next to inner collection
        {
            return Inner != null && InnerItems.Count > 0;
        }
    }
