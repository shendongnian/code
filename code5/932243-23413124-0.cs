    public class ByteArraySegment : ICollection<byte>
    { 
        private readonly byte[] array;
        private readonly int start;
        private readonly int count;
        public ByteArraySegment(...)
        {
            // Obvious code
        }
        public void CopyTo(byte[] target)
        { 
            Buffer.BlockCopy(array, start, target, 0, count);
        }
        // Other ICollection<T> members
    }
