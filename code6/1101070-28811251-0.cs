    public class User
    {
        public User()
        {
            Device = new Device();
        }
    
        public int UserID { get; set; }
    
        public string CodeName { get; set; }
    
        public bool UseBriefInstructions { get; set; }
    
        public Device Device { get; set; }
    }
