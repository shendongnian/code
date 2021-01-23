    public class Filtered<T>
    {
        private IEnumerable<T> _list;
        private IEnumerable<T> _filteredList;
    
        public bool IsFiltered { get; set; }
    
        public IEnumerable<T> MyCollection { get { return IsFiltered ? _filteredList 
                                                                     : _list; }}
    
        public Filtered(IEnumerable<T> list, IEnumerable<T> filteredList)
        {
            _list = list;
            _filteredList = filteredList;
        }
    }
