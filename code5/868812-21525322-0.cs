    public class NewModel
    {
        [RegularExpression("^[A-Z][A-Za-z]{3,19}$", ErrorMessage="First character of name should be capital")]
        public string Name { get; set; }
    }
