    public class SomeModel : IEntity
    {
       public CustomType SomeProperty { get; set; }
       public OneMoreCustomType AnotherProrerty { get; set; }
    
       public void Prepare()
       {
          SomeProperty.Prepare();
          AnotherProperty.Prepare();
       }
    }
