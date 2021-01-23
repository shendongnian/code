    public class AttendeeResponse
    {
        public IsAttending? Isattending { get; set; }
    }
    public enum IsAttending
    {
        [Display(Name = "Attending")]
        Attending,
        [Display(Name = "Not attending")]
        NotAttending
    }
