    public class MyModel
    {
       [Required, RegularExpression("your_regex_pattern", ErrorMessage="Your custom message")]
       public string Valor { get; set; }
    }
