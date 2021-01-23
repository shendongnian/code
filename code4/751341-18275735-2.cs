    [MetadataType(typeof(MyModelMetadata))]
    public partial class MyModel : IMyEntity
    {
       [Bind()]  
       public class MyModelMetadata
       {
          [Required]
          public object MyProperty { get; set; }
       }
    }
