    public interface INonGeneric
    {
        object Value {get; }
    }
    public interface IGeneric<T>
    {
        T Value { get; }
    }
    public class Magic : INonGeneric, IGeneric<string>
    {
        object INonGeneric.Value { get { return this.Value; } }
        public string Value { get { return "test"; } }
    }
