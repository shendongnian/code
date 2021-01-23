    public class ArrayReference<T>
    {
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
    }
