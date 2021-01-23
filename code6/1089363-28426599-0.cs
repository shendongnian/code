    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime Date { get; set; }
    
        public int DoctorID { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser Doctor { get; set; }
    
        public int SystemUserID { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser SystemUser { get; set; }
    }
    
    public class ApplicationUser
    {
    	public int ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FirstNsme { get; set; }
        public string LastName { get; set; }
    	public UserType UserType { get; set; }
    }
    
    public enum UserType
    {
    	Doctor,
    	SystemUser
    }
