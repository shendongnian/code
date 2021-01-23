    public class ViewModel
    {
        [Required]
        public string PropertyOne { get; set; }
        [Required]
        public string PropertyTwo { get; set; }
    }
    ...
    var model = new ViewModel();
    var results = new List<ValidationResult>();
    if (!Validator.TryValidateObject(model, new ValidationContext(model), results)) {
        Console.WriteLine("Model is not valid:");
        foreach (var r in results) {
            Console.WriteLine(r.ErrorMessage);
        }
    } else {
        Console.WriteLine("Model is valid");
    }
