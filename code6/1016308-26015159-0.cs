    public class User {
        public string Email { get; set; }
    }
    [MetadataType(typeof(InsertUserModelMetadata))]
    public class InsertUserModel : User {
    }
    
    
    internal class InsertUserModelMetadata {
        [Required]
        public string Name { get; set; }
    }
