    public class MyEntity
    {
      // ...
      [NotMapped]
      public EnumType Value 
      {
        get { /* return KeyForEnum converted to EnumType value */ }
        set { /* set KeyForEnum value from the received EnumType value*/}
      }
      // Use some mechanism to map this private property
      private string KeyForEnum { get; set; } 
      // ...
    }
