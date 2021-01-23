    public interface IBase { }
    
    public class T1 : IBase { }
    public class T2 : IBase { }
    
    public class ClassA<TA> where TA: IBase { }
    public class ClassB<TB> where TB: IBase { }
