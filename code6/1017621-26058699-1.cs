    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            User u2 = obj as User;
            if (u2 == null) return false;
            return UserId == u2.UserId;
        }
        public override int GetHashCode()
        {
            return UserId;
        }
    }
    class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            Group g2 = obj as Group;
            if (g2 == null) return false;
            return GroupId == g2.GroupId;
        }
        public override int GetHashCode()
        {
            return GroupId;
        }
    }
