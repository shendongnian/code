    public class Taco : IAuditableEntity 
    { 
      [AuditableProperty]
      public string Seasoning { get; set; } 
      [AuditableProperty]
      public string OtherProperty1 { get; set; } 
 
      public string OtherProperty2 { get; set; } 
    }
