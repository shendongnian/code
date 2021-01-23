    public class ArrayReference<T> : IEnumerable<T>
    {
        //you can keep these entirely private if you prefer
        public T[] Array { get; private set; }
        public int Offset { get; private set; }
        public ArrayReference(T[] array, int offset)
        {
            Array = array;
            Offset = offset;
        }
        public T this[int index]
        {
            get
            {
                return Array[index + Offset];
            }
            set
            {
                Array[index + Offset] = value;
            }
        }
        public int Length
        {
            get
            {
                return Array.Length - Offset;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Offset; i < Array.Length; i++)
                yield return Array[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public static ArrayReference<T> operator +(
            ArrayReference<T> reference, int offset)
        {
            return new ArrayReference<T>(reference.Array, reference.Offset + offset);
        }
        public static ArrayReference<T> operator -(
            ArrayReference<T> reference, int offset)
        {
            return new ArrayReference<T>(reference.Array, reference.Offset - offset);
        }
        public static implicit operator ArrayReference<T>(T[] array)
        {
            return new ArrayReference<T>(array, 0);
        }
        public static implicit operator T[](ArrayReference<T> reference)
        {
            return reference.ToArray();
        }
    }
