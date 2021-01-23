    [Validator(typeof(ViewModelValidator))]
    public class ViewModel
    {
         [Required]
         public int? Minimum { get; set; }
    
         [Required]
         public int? Maximum { get; set; }
    }
