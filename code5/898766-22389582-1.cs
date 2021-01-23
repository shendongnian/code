    public class DropDownListModel<T>
    {
        public T SelectedItem { get; set; }
    
        public IEnumerable<T> Items { get; set; }
    }
