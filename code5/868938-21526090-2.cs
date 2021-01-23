    public class ListViewModel<T, U>
    {
        public IEnumerable<T> Items { get; set; }
        public IEnumerable<U> OtherItems { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
    var vm = new ListViewModel<string, int>();
