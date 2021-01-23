        /// <summary>
        /// Abstract Generic base class
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        public abstract class CustomList<T>
        {
            private List<T> _list;
    
            public CustomList()
            {
                _list = new List<T>();
            }
    
            public T this[int i]
            {
                get
                {
                    return _list[i];
                }
            }
    
            public void Add(T item)
            {
                if (this.ValidateItem(item))
                    _list.Add(item);
                else
                    throw new ApplicationException("Your exception here");
            }
    
            /// <summary>
            /// Validation method
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            protected abstract bool ValidateItem(T item);
        }
    
        /// <summary>
        /// Int list type
        /// </summary>
        public class IntCustomList : CustomList<int>
        {
            protected override bool ValidateItem(int item)
            {
                return item % 2 == 0;
            }
        }
    
        /// <summary>
        /// Test class
        /// </summary>
        public class Test
        {
            public void Test()
            {
    
                IntCustomList list = new IntCustomList();
    
                list.Add(1);
                list.Add(2);
            }
        }
