    public class Bonus
    {
        public int spy_defense { get; set; }
        public int plunder { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int spy_attack { get; set; }
    }
    
    public class User
    {
        public string username { get; set; }
        public int user_id { get; set; }
        public List<object> recent_gifts { get; set; }
        public int class_id { get; set; }
        public Bonus bonus { get; set; }
        public object superpower_expire_date { get; set; }
        public int avatar_id { get; set; }
        public int avatar_type { get; set; }
        public object cost { get; set; }
    }
    
    public class RootObject
    {
        public List<User> users { get; set; }
    }
