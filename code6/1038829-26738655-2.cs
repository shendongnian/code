    public class DecomposedMatrix<T> : DecomposedMatrix, IReadOnlyList<T>
    {
        private readonly IList<T> data;
        public DecomposedMatrix(int h, int w, int d)
                : base(h, w, d)
        {
            this.data = new T[h * w * d];
        }
        public T this[int index]
        {
            get
            {
                return this.data[index];
            }
            set
            {
                this.data[index] = value;
            }
        }
        public T this[int x, int y, int z]
        {
            get
            {
                return this.data[this.DereferenceCoordinates(x, y, z)];
            }
            set
            {
                this.data[this.DereferenceCoordinates(x, y, z)] = value;
            }
        }
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
        public IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
    }
