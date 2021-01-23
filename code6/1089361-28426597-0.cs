    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime Date { get; set; }
    
        public Guid DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public virtual ApplicationUser Doctor { get; set; }
    
        public Guid SystemUserID { get; set; }
        [ForeignKey("SystemUserID ")]
        public virtual ApplicationUser SystemUser { get; set; }
    }
