    public interface IGetObject<T>
    {
       void GetObjectBy(T Id);
    }
    
    public class Class1 : IGetObject<int> {
       void GetObjectBy(int Id);
    }
    
    public class Class2 : IGetObject<Guid> {
       void GetObjectBy(Guid Id);
    }
