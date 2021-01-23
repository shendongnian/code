    public class CreateAppointmentSelectOptionsViewModel
    {
        public Guid AppointmentId { get; set; }
    
    
        [Display(Name = "Repeat times")]
        [Range(1,5,ErrorMessage="Repeat times must be between {1} and {2}")]
        public int RepeatTimes { get; set; }
    
        public string Question1Answer { get; set; } // should have a more meaningful name
    
        public string Question2Answer { get; set; } 
    }
