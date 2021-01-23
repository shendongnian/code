    public class Book
    {
        private HashSet<string> _number;
        public Book(string[] id)
        {
            _number = new HashSet<string>(id, StringComparer.InvariantCultureIgnoreCase);
        }
        public bool Exist(string id)
        {
            return _number.Contains(id);
        }
        public void AddBook(string id)
        {
            _number.Add(id);
        }
    }
