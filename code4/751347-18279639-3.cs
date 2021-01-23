    [MetadataType(typeof(IMyEntityValidation))]
    public partial class MyModel : IMyEntity
    {
      public object CreatedOn { get; set; }
      public string Username { get; set; }  
    }
