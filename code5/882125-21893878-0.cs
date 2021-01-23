    /// <summary>
    /// A enumeration of all possible partitions of a set of items.
    /// </summary>
    /// <typeparam name="T">The type of the items in the set being partitioned.</typeparam>
    public sealed class AllPartitionsEnumerable<T> : IEnumerable<IEnumerable<IEnumerable<T>>>
    {
        /// <summary></summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        private IEnumerable<T> items;
        /// <summary>
        /// Creates and initializes an instance of the <see cref="AllPartitionsEnumerable{T}"/> type.
        /// </summary>
        /// <param name="items">The set of items to be partitioned.</param>
        public AllPartitionsEnumerable(IEnumerable<T> items)
            : base ()
        {
            this.items = items;
        }
        /// <summary>
        /// Gets an enumerator to iterate over the partitions in this enumeration.
        /// </summary>
        /// <returns>An instance of <see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<IEnumerable<IEnumerable<T>>> GetEnumerator()
        {
            return new AllPartitionsEnumerator<T>(this.items);
        }
        /// <summary>
        /// Gets an enumerator to iterate over the partitions in this enumeration.
        /// </summary>
        /// <returns>An instance of <see cref="IEnumerator{T}"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
     /// <summary>
    /// An enumerator to iterate over the items in an instance of <see cref="AllPartitionsEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items in the set being partitioned.</typeparam>
    public sealed class AllPartitionsEnumerator<T> : IEnumerator<IEnumerable<IEnumerable<T>>>
    {
        /// <summary>The original set of items over which partitions are created.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private T[] items;
        /// <summary>Flag to indicate if this enumerator has been disposed of.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool isDisposed;
        /// <summary>Flag to indicate if this enumerator is in its initial state.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool isFirst;
        /// <summary>The number of partitions in the current selection.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int nc;
        /// <summary>An array of values indicating the number of values in the partition at the specified index.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int[] p;
        /// <summary>An array of indices indicating to which partition the item at the specified index belongs.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int[] q;
        /// <summary>The current partition.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private T[][] current;
        /// <summary>
        /// Creates and initializes an instance of the <see cref="AllPartitionsEnumerator{T}"/> type.
        /// </summary>
        /// <param name="items">The original set of items over which partitions are enumerated.</param>
        public AllPartitionsEnumerator(IEnumerable<T> items)
            : base()
        {
            if (null == items)
            {
                throw new ArgumentNullException("items");
            }
            this.isFirst = true;
            this.items = items.ToArray();
            this.nc = 0;
            this.p = new int[this.items.Length];
            this.q = new int[this.items.Length];
            this.current = null;
        }
        /// <summary>
        /// Gets the current partition.
        /// </summary>
        public IEnumerable<IEnumerable<T>> Current
        {
            get
            {
                this.CheckIfDisposed();
                return this.current;
            }
        }
        /// <summary>
        /// Disposes of this enumerator and releases all resources held by it.
        /// </summary>
        public void Dispose()
        {
            if (this.isDisposed)
            {
                return;
            }
            this.isDisposed = true;
            this.items = null;
            this.p = null;
            this.q = null;
            this.nc = 0;
            this.current = null;
            this.isFirst = true;
        }
        /// <summary>
        /// Gets the current partition.
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }
        /// <summary>
        /// Selects the next item in the set of all partitions.
        /// </summary>
        /// <returns><c>true</c> if an item was selected; <c>false</c> if we are past the last element.</returns>
        public bool MoveNext()
        {
            this.CheckIfDisposed();
            if (this.isFirst)
            {
                this.isFirst = false;
                this.nc = 1;
                this.p[0] = this.items.Length;
                for (int i = 0; i < this.items.Length; ++i)
                {
                    this.q[i] = this.nc;
                }
                this.Select();
                return true;
            }
            if (this.nc == this.items.Length )
            {
                return false;
            }
            int n = this.items.Length;
            int m = n;
            int l = this.q[m-1];
            while (this.p[l - 1] == 1)
            {
                this.q[m - 1] = 1;
                --m;
                l = this.q[m - 1];
            }
            this.nc += m - n;
            this.p[0] = this.p[0] + n - m;
            if (l == this.nc)
            {
                ++this.nc;
                this.p[this.nc - 1] = 0;
            }
            this.q[m - 1] = l + 1;
            this.p[l - 1] = this.p[l - 1] - 1;
            this.p[l] = this.p[l] + 1;
            this.Select();
            return true;
        }
        /// <summary>
        /// Resets this enumerator to its initial state.
        /// </summary>
        public void Reset()
        {
            this.CheckIfDisposed();
            this.current = null;
            this.isFirst = true;
            this.isDisposed = false;
            this.p = new int[this.items.Length];
            this.q = new int[this.items.Length];
            this.nc = 0;
        }
        /// <summary>
        /// Selects the items for the current partition.
        /// </summary>
        private void Select()
        {
            this.current = new T[this.nc][];
            for (int i = 0; i < this.nc; ++i)
            {
                int k = 0;
                this.current[i] = new T[this.p[i]];
                for (int j = 0; j < this.items.Length; ++j)
                {
                    if (this.q[j] == i + 1)
                    {
                        this.current[i][k] = this.items[j];
                        ++k;
                    }
                }
            }
        }
        /// <summary>
        /// Checks and throws an exception if this enumerator has been disposed.
        /// </summary>
        private void CheckIfDisposed()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }
    }
        /// <summary>
        /// Retrieves all possible partitions of a set of items.
        /// </summary>
        /// <typeparam name="T">The type of the items in the original set.</typeparam>
        /// <param name="items">The original set of items over which partitions are created.</param>
        /// <returns>All possible partitions of the items in <paramref name="items"/>.</returns>
        public static IEnumerable<IEnumerable<IEnumerable<T>>> AllPartitions<T>(this IEnumerable<T> items)
        {
            return new AllPartitionsEnumerable<T>(items);
        }
