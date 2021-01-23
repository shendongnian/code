    public class YourViewModel
    {
         //Other properties
         [Range(1,int.MaxValue,ErrorMessage = "Select a correct License Type")]
         public LicenseTypes LicenseTypes { get; set; }
    }
