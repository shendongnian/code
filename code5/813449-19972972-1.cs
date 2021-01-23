    public static class Ext
    {
        public static void Serialize(this Guid guid_, StringWriter sw_)
        {
            sw_.Write(guid_.ToString("B"));
        }
    }
    public class Field<T> where T: ISerializableField
    {
        public T value;
        public void Serialize(StringWriter sw_)
        {
            value.Serialize(sw_);
        }
    }
    public interface ISerializableField
    {
        void Serialize(StringWriter sw);
    }
    public class SerializableGuid : ISerializableField
    {
        private readonly Guid _guid;
        public SerializableGuid(Guid guid)
        {
            _guid = guid;
        }
        public void Serialize(StringWriter sw)
        {
            _guid.Serialize(sw);
        }
    }
