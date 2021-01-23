    public class Appointment
    {
      public int AppointmentID { get; set; }
      public string AppointmentCode { get; set; }
      public string? ApplicationUserId { get; set; }
      [ForeignKey("ApplicationUserId ")]
      public ApplicationUser ApplicationUser { get; set; }
      public int PriceId { get; set; }
    } 
