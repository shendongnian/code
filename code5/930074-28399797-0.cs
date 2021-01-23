    namespace Naive
    {
        using System;
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
    
        public class ThreadSafeCollectionNaive<T>
        {
            private readonly List<T> _list = new List<T>();
            private readonly object _criticalSection = new object();
    
            /// <summary>
            /// This is consumed in the UI. This is O(N)
            /// </summary>
            public ReadOnlyCollection<T> GetContentsCopy()
            {
                lock (_criticalSection)
                {
                    return new List<T>(_list).AsReadOnly();
                }
            }
    
            /// <summary>
            /// This is a hacky way to handle updates, don't want to write lots of code
            /// </summary>
            public void Update(Action<List<T>> workToDoInTheList)
            {
                if (workToDoInTheList == null) throw new ArgumentNullException("workToDoInTheList");
    
                lock (_criticalSection)
                {
                    workToDoInTheList.Invoke(_list);
                }
            }
    
            public int Count
            {
                get
                {
                    lock (_criticalSection)
                    {
                        return _list.Count;
                    }
                }
            }
    
            // Add more members as you see fit
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var collectionNaive = new ThreadSafeCollectionNaive<string>();
    
                collectionNaive.Update((l) => l.AddRange(new []{"1", "2", "3"}));
    
                collectionNaive.Update((l) =>
                                           {
                                               for (int i = 0; i < l.Count; i++)
                                               {
                                                   if (l[i] == "1")
                                                   {
                                                       l[i] = "15";
                                                   }
                                               }
                                           });
            }
        }
    }
