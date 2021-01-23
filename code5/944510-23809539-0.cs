    // Do no edit this class as it is auto generated
    public partial class ModelA
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
    }
    
    // This class can be edited
    [MetadataType(typeof(ModelA.Metadata))]
    public partial class ModelA
    {
        public class Metadata
        {
             [Required]
             public object Property1 { get; set; }
    
             [Required]
             public object Property2 { get; set; }
    
        }
    }
