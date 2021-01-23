    public class Video : IAbstractDomainEntity<string>
    {
        private string _id;
        private string _title;
        private string _author;
        public virtual string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public virtual string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public virtual int Duration { get; set; }
        public virtual bool HighDefinition { get; set; }
        public Video()
        {
            _id = string.Empty;
            _title = string.Empty;
            _author = string.Empty;
        }
    }
