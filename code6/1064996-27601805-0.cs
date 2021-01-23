    struct User
    {
        int id;
        string document;
        public int Id
        {
            get { return id; }
        }
        public string Document
        {
            get { return document; }
        }
        public User(int id, string document)
        {
            this.id = id;
            this.document = document;
        }
    }
