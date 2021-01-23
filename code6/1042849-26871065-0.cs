    abstract class Base<T>
    {
        public abstract T Decode(byte[] input);
    }
    class StringDecoder : Base<string>
    {
        public override string Decode(byte[] input)
        {
            return Encoding.UTF8.GetString(input);
        }
    }
