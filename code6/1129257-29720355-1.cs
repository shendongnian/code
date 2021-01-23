    public interface IKey
    {
        bool Equals(object value);
        int GetHashCode();
    }
    public struct KeyStruct : IKey
    {
    }
    public class KeyClass :IKey
    {
    }
    public class MyDictionary<TKey, TValue> where TKey : IKey
    {
    }
