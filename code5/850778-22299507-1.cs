    public class SomeModel {
    
        [DataType(DataType.EmailAddress)]
        [Display(Name="Some string for LabelFor", Prompt = "Placeholder in input"]
        public string SomeEmail { get; set; }
    }
