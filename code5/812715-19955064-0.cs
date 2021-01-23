    // generated code
    public partial class Whatever : ISomeInterface<MyTable>
    {
        //...
    }
    //somewhere else
    public interface ISomeInterface<T>
    {
        void Insert(T instance);
        void Update(T instance);
    }
