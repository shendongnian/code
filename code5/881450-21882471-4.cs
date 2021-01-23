    public class YourViewModel
    {
         //Other properties
         [Range(1,int.MaxValue,ErrorMessage = "Select a correct license")]
         public LicenseTypes LicenseTypes { get; set; }
    }
