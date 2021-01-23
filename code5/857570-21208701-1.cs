    public class Post
    {
        private Guid _guid = new Guid();
        public Guid userguid
        {
            get { return _guid; }
            set { _guid = value; }
        }
    }
