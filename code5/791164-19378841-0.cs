    public interface IGenericObject<out T>
    {
        string Key { get; }
        T Value { get; }
    }
    public abstract class GenericObject<T> : IGenericObject<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
        protected GenericObject() { }
        protected GenericObject(string key, T value)
            : this()
        {
            this.Key = key;
            this.Value = value;
        }
    }
    public class GenericList<TGenericObject> : IXmlSerializable
        where TGenericObject : IGenericObject<object>
    {
        private readonly List<TGenericObject> _list = new List<TGenericObject>();
        public void Add(TGenericObject item)
        {
            _list.Add(item);
        }
        public XmlSchema GetSchema()
        {
            // ...
        }
        public void ReadXml(XmlReader reader)
        {
            // ...
        }
        public void WriteXml(XmlWriter writer)
        {
            // ...
        }
    }
    public class Person : GenericObject<string>
    {
    }
