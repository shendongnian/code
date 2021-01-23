    public class Matrix<T>
    {
        public T Obj { get; set; }
    }
    public interface INonGenericWrapper
    {
        void Wrap();
        void Accept(IVisitor visitor);
    }
    public class Wrapper<T> : INonGenericWrapper
    {
        public Matrix<T> Matrix { get; private set; }
        public void Wrap()
        {
            //Your domain specific method
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public interface IVisitor
    {
        void Visit<T>(T element);
    }
    public class SerializationVisitor : IVisitor
    {
        public void Visit<T>(T element)
        {
            new Serializer<T>().Serialize(element);
        }
    }
    public class Serializer<T>
    {
        public Stream Serialize(T objectToSerialize)
        {
            Console.WriteLine("Serializing {0}", objectToSerialize);
            //Your serialization logic here
            return null;
        }
    }
