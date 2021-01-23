    public class SaveResult
    {
        public PersonDto { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
    var result = Save(person);
    
    if (!result.Success)
    {
        Console.WriteLine(result.ErrorMessage);
    }
