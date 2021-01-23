    public class MyModel
    {
       [Required, RegularExpression("pattern_to_match", ErrorMessage="Your custom message")]
       public string Valor { get; set; }
    }
