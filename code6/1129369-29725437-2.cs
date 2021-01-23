    class User
    {
        private string _name;
        private int _id;
        public User(string name, int id)
        {
            _name = name;
            _id = id;
        }
        public string GetName() { return _name; }
        public int GetId() { return _id; }
    }
