    public class Queue<T> 
    {
        // *** You need to be able to compare elements in 'Min()' ***
        private readonly IComparer<T> _comparer;
        // *** Allocate a small initial size if no capacity given ***
        private const int DefaultCapacity = 4;
        #region Properties
        /// <summary>
        /// The capacity of the Elements Collection
        /// </summary>
        public int Capacity
        {
            // *** The number of allocated elements == capacity ***
            get { return Elements.Length; } 
        }
        // *** For each of these properties:
        // (1) you don't need a backing field, you can use an "auto property".
        // (2) don't make the "set" operation available to clients of the class: 
        //     make it "private".
        /// <summary>
        /// The number of elements currently in the queue.
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// The actual data elements stored in the queue.
        /// </summary>
        protected T[] Elements { get; private set; }
        /// <summary>
        /// This is the index where we will dequeue.
        /// </summary>
        public int FrontIndex { get; private set; }
        /// <summary>
        /// This is the index where we will next enqueue a value. 
        /// It is calculated based on the Front Index, Length, and Capacity
        /// </summary>
        public int BackIndex
        {
            get { return (FrontIndex + Length) % Capacity; }
        }
        #endregion
        #region Constructors
        /*** Allows supplying a comparer to find the minimum */
        public Queue(IComparer<T> comparer = null) : this(DefaultCapacity, comparer)
        {
        }
        public Queue(int capacity, IComparer<T> comparer = null)
        {
            // *** Ensure capacity > 0 ***
            Elements = new T[capacity > 0 ? capacity : DefaultCapacity];
            _comparer = comparer ?? Comparer<T>.Default; // *** We need a comparer ****
        }
        #endregion
        #region public methods
        public void Enqueue(T element)
        {
            if (this.Length == Capacity)
            {
                IncreaseCapacity();
            }
            Elements[BackIndex] = element;
            Length++;
        }
        public T Dequeue()
        {
            if (this.Length < 1)
            {
                throw new InvalidOperationException("Error: Queue is empty");
            }
            T element = Elements[FrontIndex];
            Elements[FrontIndex] = default(T);
            Length--;
            FrontIndex = (FrontIndex + 1) % Capacity;
            return element;
        }
        public T Peek()
        {
            if (this.Length < 1)
            {
                throw new InvalidOperationException("Error: Queue is empty");
            }
            return Elements[FrontIndex]; // *** You need to index by FrontIndex ***
        }
        // *** Added to allow easy enumeration. ***
        public IEnumerable<T> Items
        {
            get
            {
                for (var i = 0; i < Length; i++)
                    yield return Elements[(FrontIndex + i) % Capacity];
            }
        }
        public T Min() 
        {
            // *** Cannot get min if there are no items.
            if (Length < 1)
                throw new InvalidOperationException("Error: Queue is empty");
            // *** Need to start searching from FrontIndex
            var min = Elements[FrontIndex];
            for (var i = 1; i < Length; i++)
            {
                var item = Elements[(FrontIndex + i) % Capacity];
                // *** Need  the comparer for comparison of 'T'
                if (_comparer.Compare(min, item) > 0) // 'min' > 'item'
                    min = item;
            }
            return min;
        }
        public void Display()
        {
            foreach (T item in Items) // *** We can use the "Items" enumerable here.
            {
                Console.Write(item);
                Console.Write("-->");
            }
            Console.WriteLine();
        }
        #endregion
        #region private methods
        /// <summary>
        /// Private function for increasing the size of the queue 
        /// if we run out of space and need to add another element
        /// </summary>
        private void IncreaseCapacity()
        {
            // *** Need to allocate a new larger array for the items
            var newElementsArray = new T[this.Capacity * 2];
            // *** And fill it with our current elements sequentially
            var ndx = 0;
            foreach (var item in Items)
                newElementsArray[ndx++] = item;
            // *** Now we can assign it and reset the front index.
            this.Elements = newElementsArray;
            this.FrontIndex = 0;
        }
        #endregion
    }
