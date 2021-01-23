    public interface IClass1 { string myVar; }
    public interface IClass2 : IClass1 { new string myVar;}
    public class Class1 : IClass1 
    {
        string IClass1.myVar = 10;
    }
    public class Class1 : IClass2 
    {
        string IClass1.myVar = 10;
        string IClass2.myVar = 15;
    }
