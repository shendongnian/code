    public struct PseudoGuid : IReadOnlyList<byte>, IEquatable<PseudoGuid>
    {
        private readonly byte[] value;
        public PseudoGuid(IList<byte> value)
        {
            if (value.Count != 16)
            {
                throw new ArgumentException(...
            }
            this.value = value.ToArray();
        }
        public byte this[int index]
        {
            get
            {
                if (this.value != null)
                {
                    return this.value[index]
                }
                return default(byte);
            }
        }
        public bool Equals(PseudoGuid other)
        {
            return this.SequenceEquals(other);
        }
        public override string ToString()
        {
            var result = new StringBuilder(32);
            for (var i = 0; i < 16; i++)
            {
                result.Append(this[i].ToString("X2"));
            }
            return result.ToString();
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is PseudoGuid && this.Equals((PseudoGuid)obj);
        }
        public override int GetHashCode()
        {
            if (this.value == null)
            {
                return 0;
            }
            return BitConvertor.ToInt32(this.value, 0) ^
                BitConvertor.ToInt32(this.value, 4) ^
                BitConvertor.ToInt32(this.value, 8) ^
                BitConvertor.ToInt32(this.value, 12);
        }
        public static bool operator ==(PseudoGuid left, PseudoGuid right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(PseudoGuid left, PseudoGuid right)
        {
            return !left.Equals(right);
        }
        public int Count
        {
            get
            {
                return 16;
            }
        }
        public IEnumerator<byte> GetEnumerator()
        {
            if (this.value != null)
            {
                return ((IList<byte>)this.value).GetEnumerator();
            }
            return Enumerable.Repeat(default(byte), 16).GetEnumerator();
        }
        System.Collections.IEnumerator
                 System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
