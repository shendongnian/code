    public class User
    {
        protected bool Equals(User other)
        {
            return ID == other.ID && MI == other.MI;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (ID*397) ^ MI;
            }
        }
        public int ID { get; set; }
        public int MI { get; set; }
        public User(int id, int mi)
        {
            ID = id; //based on @Jonesy comment
            MI = mi;
        }
    }
