    public partial class xxx
    {
    [RegularExpression(@"^\+?\(?([0-9]{2})\)?([ .-]?)([0-9]{4})\2([0-9]{4})", ErrorMessage = "")]
    public string MobileNumber { get; set; }
    }
