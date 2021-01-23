    public interface ISomeClass
    {
         Manager m { get; set; }
         SpecialData data { get; set; }
    }
    public class SomeClass : ISomeClass
    {
         public Manager m { get; protected set; }
         SpecialData ISomeClass.data { get; protected set; }
         //More methods and member code here...
    }
