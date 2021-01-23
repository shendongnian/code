    public class ByteArraySegment : ICollection<byte>
    { 
        private readonly byte[] array;
        private readonly int start;
        private readonly int count;
        public ByteArraySegment(...)
        {
            // Obvious code
        }
        public void CopyTo(byte[] target, int index)
        { 
            Buffer.BlockCopy(array, start, target, index, count);
        }
        // Other ICollection<T> members
    }
