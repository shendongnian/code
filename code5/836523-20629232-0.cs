    public interface IStruct {
         string Name {get;set;}
    }
    
    public struct Derived : IStruct {
         public string Name {get;set;}
    }
