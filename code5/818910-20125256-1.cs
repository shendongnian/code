    public interface IGetObject
    {
       void GetObjectBy(int Id);
       void GetObjectBy(Guid Id);
    }
    
    public class Class1 : IGetObject {
       void GetObjectBy(int Id);
       void GetObjectBy(Guid Id);
    }
    
    public class Class2 : IGetObject<Guid> {
       void GetObjectBy(int Id);
       void GetObjectBy(Guid Id);
    }
