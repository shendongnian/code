    [Validator(typeof(QuoteValidator))]
    public class QuoteViewModel
    {
        [Display(Name = @"Day")]
        public int DateOfBirthDay { get; set; }
    
        [Display(Name = @"Month")]
        public int DateOfBirthMonth { get; set; }
    
        [Display(Name = @"Year")]
        public int DateOfBirthYear { get; set; }
    
        [Display(Name = @"Gender")]
        public Gender? Gender { get; set; }
    
        [Display(Name = @"State")]
        public int StateId { get; set; }
    }
