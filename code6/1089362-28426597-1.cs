    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public DateTime Date { get; set; }
    
        public string DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public virtual ApplicationUser Doctor { get; set; }
    
        public string SystemUserID { get; set; }
        [ForeignKey("SystemUserID ")]
        public virtual ApplicationUser SystemUser { get; set; }
    }
