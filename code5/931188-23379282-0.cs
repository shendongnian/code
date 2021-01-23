    public interface IGenericModel<out T> where T : IBaseTest
    {
        IEnumerable<T> GetAll(); // just as an example
    }
    
    public interface IBaseTest
    {
        T Property { get; }
    }
