    public class User
    {
        [Key, Column("un")]
        public string Username { get; set; }
        public int Level { get; set; }
        //here is your foreign to UserSettings
        public int? UserSettingsID{ get; set; }
    
        [ForeignKey("UserSettingsID")] // not needed if you're using the '%ID' convention
        //Navigation property
        public virtual UserSettings UserSettings { get; set; }
    }
    
    public class UserSettings
    {
        //UserSettings PK
        public int UserSettingsID{ get; set; }
        public int ActiveRefresh { get; set; }
    }
