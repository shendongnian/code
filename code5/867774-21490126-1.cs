      [MetadataType(typeof(PatientMetadata))]
      public partial class Patient
      {
        public class PatientMetadata
        {
          [Required]
          public string Name { get; set; }
    
          ....
    
        }
      }
