    public class MyModel
    {
      public string MyString { get; set; }
      public string MyHiddenField { get; set; }
    }
    public interface IMyModel_ValidateMystringOnly
    {
      [Required]
      string MyString { get; set; }
    }
    [MetadataType(TypeOf(IMyModel_ValidateMystringOnly))]
    public class MyModel_ValidateMystringOnly : MyModel
