    namespace Validation.Access
    {
        [MetadataType(typeof(TransferModuleValidation))]
        public partial class Sales { }
        [MetadataType(typeof(TransferModuleValidation))]
        public partial class Product { }
        public partial class TransferModuleValidation
        {
            [MaxLength(3, ErrorMessage = "Must be less than or 3 characters")]
            public string Currency { get; set; 
        }
    }
