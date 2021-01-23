    public class MyBinaryReader : BinaryReader, IEnumerable<byte>
    {
        public MyBinaryReader(Stream input)
            : base(input)
        {
        }
        public MyBinaryReader(Stream input, Encoding encoding)
            : base(input, encoding)
        {
        }
        public IEnumerator<byte> GetEnumerator()
        {
            while (BaseStream.Position < BaseStream.Length)
                yield return ReadByte();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
