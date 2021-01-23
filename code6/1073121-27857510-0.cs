    class User
    {
        public string FirstName;
        public string LastName;
        [BsonIgnoreIfNull]
        public string MidName;
    }
