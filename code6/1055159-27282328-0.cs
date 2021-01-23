    public class Customer
    {
        public string MyId { get; set; }
        public int UserPreferencesID { get; set; }
        public virtual UserPreferences Preferences { get; set; }
    }
    
    public class UserPreferences
    {
        public int ID { get; set; }
        public bool Bool1 { get; set; }
        public bool Bool2 { get; set; }
        public bool Bool3 { get; set; }
        public bool Bool4 { get; set; }
        public bool Bool5 { get; set; }
    }
