        /// <summary>
        /// A generic buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Buffer<T>
        {
            /// <summary>
            /// The internal buffer.
            /// </summary>
            protected T[] _array;
            /// <summary>
            /// Creates a new generic buffer.
            /// </summary>
            /// <param name="array">The array.</param>
            public Buffer(T[] array)
            {
                _array = new T[array.Length];
                Array.Copy(array, 0, _array, 0, _array.Length);
            }
            /// <summary>
            /// Creates a new generic buffer.
            /// </summary>
            /// <param name="capacity">The capacity.</param>
            public Buffer(int capacity)
            {
                _array = new T[capacity];
                // 0 filling for value-types
                for (int i = 0; i < _array.Length; i++)
                    _array[i] = default(T);
            }
            /// <summary>
            /// Gets the first value of the buffer.
            /// </summary>
            public T First
            {
                get { return _array[0]; }
            }
            /// <summary>
            /// Gets the last value of the buffer.
            /// </summary>
            public T Last
            {
                get { return _array[_array.Length - 1]; }
            }
            /// <summary>
            /// Gets the length of the buffer.
            /// </summary>
            public int Length
            {
                get { return _array.Length; }
            }
            /// <summary>
            /// Gets values in the form of an array from a specific index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <param name="length">The length.</param>
            /// <returns>Returns the values in the form of an array.</returns>
            public T[] Get(int index, int length)
            {
                var array = new T[length];
                Array.Copy(_array, index, array, 0, length);
                return array;
            }
            /// <summary>
            /// Gets a copy of the internal array.
            /// </summary>
            /// <returns>Returns the copied array.</returns>
            public T[] Get()
            {
                var array = new T[_array.Length];
                Array.Copy(_array, 0, array, 0, array.Length);
                return array;
            }
            /// <summary>
            /// Gets a value by an index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <returns>Returns the value.</returns>
            public T GetValue(int index)
            {
                return _array[index];
            }
            /// <summary>
            /// Puts a value into the beginning of the buffer.
            /// Note: Put does not replace the first value.
            /// </summary>
            /// <param name="value">The value.</param>
            public void Put(T value)
            {
                var array = new T[_array.Length + 1];
                Array.Copy(_array, 0, array, 1, _array.Length);
                array[0] = value;
                _array = array;
            }
            /// <summary>
            /// Puts a value into a specific index of the buffer.
            /// Note: Put does not replace the value at the specific index.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="index">The index.</param>
            public void Put(T value, int index)
            {
                if (index == 0)
                {
                    Put(value);
                }
                else if (index == _array.Length - 1)
                {
                    Append(value);
                }
                else
                {
                    var array = new T[_array.Length + 1];
                    array[index] = value;
                    Array.Copy(_array, 0, array, 0, index);
                    Array.Copy(_array, index, array, index + 1, _array.Length - index);
                    _array = array;
                }
            }
            /// <summary>
            /// Inserts a value at a specific index of the buffer.
            /// Note: Insert replaces the current value at the index.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="index">The index.</param>
            public void Insert(T value, int index)
            {
                _array[index] = value;
            }
            /// <summary>
            /// Appends a value to the buffer.
            /// </summary>
            /// <param name="value">The value to append.</param>
            public void Append(T value)
            {
                var array = new T[_array.Length + 1];
                Array.Copy(_array, 0, array, 0, _array.Length);
                array[array.Length - 1] = value;
                _array = array;
            }
            /// <summary>
            /// Puts an array into the beginning of the buffer.
            /// Note: Put does not replace the first values of the buffer.
            /// </summary>
            /// <param name="value">The value.</param>
            public void Put(T[] value)
            {
                var array = new T[_array.Length + value.Length];
                Array.Copy(value, 0, array, 0, value.Length);
                Array.Copy(_array, 0, array, value.Length, _array.Length);
                _array = array;
            }
            /// <summary>
            /// Puts an array into a specific index of the buffer.
            /// Note: Put does not replace the array at the specific index.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="index">The index.</param>
            public void Put(T[] value, int index)
            {
                if (index == 0)
                {
                    Put(value);
                }
                else if (index == _array.Length - 1)
                {
                    Append(value);
                }
                else
                {
                    var array = new T[_array.Length + value.Length];
                    Array.Copy(value, 0, array, index, value.Length);
                    Array.Copy(_array, 0, array, 0, index);
                    Array.Copy(_array, index, array, index + value.Length, _array.Length - index);
                    _array = array;
                }
            }
            /// <summary>
            /// Appends an array to the buffer.
            /// </summary>
            /// <param name="value">The value.</param>
            public void Append(T[] value)
            {
                var array = new T[_array.Length + value.Length];
                Array.Copy(_array, 0, array, 0, _array.Length);
                Array.Copy(value, 0, array, _array.Length, value.Length);
                _array = array;
            }
            /// <summary>
            /// Puts a buffer into the beginning of the buffer.
            /// Note: Put does not replace the first values of the buffer.
            /// </summary>
            /// <param name="value">The value.</param>
            public void Put(Buffer<T> value)
            {
                Put(value._array);
            }
            /// <summary>
            /// Puts a buffer into a specific index of the buffer.
            /// Note: Put does not replace the buffer at the specific index.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="index">The index.</param>
            public void Put(Buffer<T> value, int index)
            {
                Put(value._array, index);
            }
            /// <summary>
            /// Appends a buffer to the buffer.
            /// </summary>
            /// <param name="value">The value.</param>
            public void Append(Buffer<T> value)
            {
                Append(value._array);
            }
            /// <summary>
            /// Gets the bytes of the buffer.
            /// </summary>
            /// <returns>Returns a newly created byte array of the buffer.</returns>
            public byte[] GetBytes()
            {
                var buffer = new byte[_array.Length * Marshal.SizeOf(typeof(T))];
                Buffer.BlockCopy(_array, 0, buffer, 0, buffer.Length);
                return buffer;
            }
        }
