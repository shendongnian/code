    public class Awesome {
        [Required]
        public Int32 Id { get; set; }
        [CustomValidation(typeof(MyValidator), "ValidateThis")]
        public String Whatever { get; set; }
    }
