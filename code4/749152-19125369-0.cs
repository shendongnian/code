    public class MyModel
    {
        [RegularExpression(@"^((?!apt).)*$", ErrorMessage = "You can not have that")]
        public string MyValue { get; set; }
    }
