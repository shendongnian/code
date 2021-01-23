    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    namespace Demo
    {
        public class CircularBuffer<T>: IEnumerable<T>
        {
            /// <summary>Constructor.</summary>
            /// <param name="capacity">The maximum capacity of the buffer.</param>
            public CircularBuffer(int capacity)
            {
                // The reason for this +1 is to simplify the logic - we can use "front == back" to indicate an empty buffer.
                _buffer = new T[capacity+1];
            }
            /// <summary>The buffer capacity.</summary>
            public int Capacity
            {
                get
                {
                    return _buffer.Length - 1;
                }
            }
            /// <summary>The number of elements currently stored in the buffer.</summary>
            public int Count
            {
                get
                {
                    int result = _back - _front;
                    if (result < 0)
                        result += _buffer.Length;
                    return result;
                }
            }
            /// <summary>Is the buffer empty?</summary>
            public bool IsEmpty
            {
                get
                {
                    return this.Count == 0;
                }
            }
            /// <summary>Is the buffer full? (i.e. has it reached its capacity?)</summary>
            public bool IsFull
            {
                get
                {
                    return nextSlot(_back) == _front;
                }
            }
            /// <summary>Empties the buffer.</summary>
            public void Empty()
            {
                _front = _back = 0;
                Array.Clear(_buffer, 0, _buffer.Length); // Destroy any old references so they can be GCed.
            }
            /// <summary>Add an element to the buffer, overwriting the oldest element if the buffer is full.</summary>
            /// <param name="newItem">The element to add.</param>
            public void Add(T newItem)
            {
                _buffer[_back] = newItem;
                _back = nextSlot(_back);
                if (_back == _front) // Buffer is full?
                {
                    _front = nextSlot(_front); // Bump the front, overwriting the current front.
                    _buffer[_back] = default(T); // Remove the old front value.
                }
            }
            /// <summary>
            /// The typesafe enumerator. Elements are returned in oldest to newest order.
            /// This is not threadsafe, so if you are enumerating the buffer while another thread is changing it you will run
            /// into threading problems. Therefore you must use your own locking scheme to avoid the problem.
            /// </summary>
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = _front; i != _back; i = nextSlot(i))
                    yield return _buffer[i];
            }
            /// <summary>The non-typesafe enumerator.</summary>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator(); // Implement in terms of the typesafe enumerator.
            }
            /// <summary>Calculates the index of the slot following the specified one, wrapping if necessary.</summary>
            private int nextSlot(int slot)
            {
                return (slot + 1) % _buffer.Length;
            }
            /// <summary>
            /// The index of the element at the front of the buffer. 
            /// If this equals _back, the buffer is empty.
            /// </summary>
            private int _front;
            /// <summary>
            /// The index of the first element BEYOND the last used element of the buffer. 
            /// Therefore this indicates where the next added element will go.
            /// </summary>
            private int _back;
            /// <summary>The underlying buffer. This has a length one greater than the actual capacity.</summary>
            private readonly T[] _buffer;
        }
        internal class Program
        {
            private void run()
            {
                CircularBuffer<int> buffer = new CircularBuffer<int>(10);
                for (int i = 0; i < 20; ++i)
                    buffer.Add(i);
                foreach (int n in buffer)
                    Console.WriteLine(n);  // Prints 10..19
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
