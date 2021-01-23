    public interface IFromString<T>
    {
        void DeserializeFromString(string str);
    }
    public class MyType : IFromString<MyType>
    {
        public int Value;
        public void DeserializeFromString(string str)
        {
            Value = int.Parse(str);
        }
    }
    public interface IParameter<T> where T : IFromString<T>, new()
    {
        T Value { get; set; }
    }
    public class Parameter<T> : IParameter<T> where T : IFromString<T>, new()
    {
        T Value { get; set; }
        public void Load(string str)
        {
            Value = new T();
            Value.DeserializeFromString(str);
        }
    }
