    public IList<MyField> MyFields {get;set;}
    public class MyField
    {
        [RegularExpression("MyRegex", ErrorMessageResourceName = "MyErrorMessage")]
        public string Value
    }
