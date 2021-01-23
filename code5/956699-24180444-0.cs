    Dep1.dll   
       Dep1Class.cs
    
    Main.dll
       References
          Dep1
       MainClass.cs
    
    OtherComponent.dll
       References
          Main
       OtherComponentClass.cs
    public class MainClass
    {
       public Dep1Class Dep1Property { get; set; }
    }
    public class OtherComponentClass
    {
       public OtherComponentClass
       {          
          var x = new MainClass();
          //// compile error, The type 'Dep1.Dep1Class' is defined in an assembly that is not referenced. You must add a reference to assembly 'Dep1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'.
          //x.Dep1Property = null;
       }
    }
