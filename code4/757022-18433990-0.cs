    public enum ActivityLevel
    {
       Sedentary,
       LightActivity,
       Moderate,
       Active,
       Extra
    }
    public class UserStats
    {
        
        public ActivityLevel ActivitySelected { get; set; }
        [Key]
        public int UserID { get; set; }
