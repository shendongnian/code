    public interface ISerializable<out T1, T2>
    {
        T2 Serialize();
        T1 Deserialize(T2 dto);
    }
    public interface IA<out T1, T2>
    {
        string Name { get; }
    }
    public interface IASerializeAware<out T1,T2> :  IA<T1, T2>, ISerializable<T1,T2>
    {
    }
    public abstract class ASerializeAwareBase<T1, T2> : Serializable<T1,T2>, IASerializeAware<T1,T2>
    {
        public string Name { get; set; }
    }
    public abstract class Serializable<T1, T2> : ISerializable<T1, T2>
    {
        public T2 Serialize()
        {
            throw new NotImplementedException();
        }
        public T1 Deserialize(T2 dto)
        {
            throw new NotImplementedException();
        }
    }
