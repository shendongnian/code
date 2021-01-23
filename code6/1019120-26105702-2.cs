    public class MyObjectBuilder
    {
        private string _author = "Default Author";
        private string _title = "Default title";
        public MyObjectBuilder WithAuthor(string author)
        {
            this._author = author;
            return this;
        }
        public MyObjectBuilder WithTitle(string title)
        {
            this._title = title;
            return this;
        }
        public MyObject Build()
        {
            return new MyObject(_author, _title);
        }
    }
