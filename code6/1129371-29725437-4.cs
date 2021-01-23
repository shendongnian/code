    class User
    {
        private readonly string _name;
        private readonly int _id;
        public User(string name, int id)
        {
            _name = name;
            _id = id;
        }
        public string GetName() { return _name; }
        public int GetId() { return _id; }
    }
