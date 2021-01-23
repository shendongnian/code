    public class TestModel
    {
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        [Display(Name = "Year")]
        public int? Year { get; set; }
    }
