        /// <summary>
        /// A 16 bit integer buffer.
        /// </summary>
        public class Int16Buffer : Buffer<short>
        {
            /// <summary>
            /// Creates a new instance of Int16Buffer.
            /// </summary>
            /// <param name="array">The array to build a buffer upon.</param>
            public Int16Buffer(short[] array)
                : base(array) { }
            /// <summary>
            /// Creates a new instance of Int16Buffer.
            /// </summary>
            /// <param name="capacity">The start capacity of the buffer.</param>
            public Int16Buffer(int capacity)
                : base(capacity) { }
        }
