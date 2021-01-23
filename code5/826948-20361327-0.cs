    using System.Collections.Generic;
    
    namespace Molten.Core
    {
        /// <summary>
        /// Represents a limited set of first-in, first-out objects.
        /// </summary>
        /// <typeparam name="T">The type of each object to store.</typeparam>
        public class LimitedQueue<T> : Queue<T>
        {
            /// <summary>
            /// Stores the local limit instance.
            /// </summary>
            private int limit = -1;
    
            /// <summary>
            /// Sets the limit of this LimitedQueue. If the new limit is greater than the count of items in the queue, the queue will be trimmed.
            /// </summary>
            public int Limit
            {
                get
                {
                    return limit;
                }
                set
                {
                    limit = value;
                    while (Count > limit)
                    {
                        Dequeue();
                    }
                }
            }
    
            /// <summary>
            /// Initializes a new instance of the LimitedQueue class.
            /// </summary>
            /// <param name="limit">The maximum number of items to store.</param>
            public LimitedQueue(int limit)
                : base(limit)
            {
                this.Limit = limit;
            }
    
            /// <summary>
            /// Adds a new item to the queue. After adding the item, if the count of items is greater than the limit, the first item in the queue is removed.
            /// </summary>
            /// <param name="item">The item to add.</param>
            public new void Enqueue(T item)
            {
                while (Count >= limit)
                {
                    Dequeue();
                }
                base.Enqueue(item);
            }
        }
    }
