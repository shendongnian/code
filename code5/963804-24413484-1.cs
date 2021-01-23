    namespace MyProjectNamespace.Models
    {
        public class CarrierBundleModel
        {
            [Required]
            [Display(Name = "Bundle ID")]
            public int BundleID{get;set;}
        
            [Required]
            [Display(Name = "Bundle Name")]
            public int BundleName{get;set;}
            
            //...Other properties you will use in the UI That match the LLBLGen Bundle class  
        }
    }
