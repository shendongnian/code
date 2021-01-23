    using System;
    using System.Collections.Generic;
    
    class LinkedHashMap<T, U>
    {
        Dictionary<T, LinkedListNode<Tuple<U, T>>> D = new Dictionary<T, LinkedListNode<Tuple<U, T>>>();
        LinkedList<Tuple<U,T>> LL = new LinkedList<Tuple<U, T>>();
    
        public U this[T c]
        {
            get
            {
                return D[c].Value.Item1;
            }
    
            set
            {
                if(D.ContainsKey(c))
                {
                    LL.Remove(D[c]);
                }
    
                D[c] = new LinkedListNode<Tuple<U, T>>(Tuple.Create(value, c));
                LL.AddLast(D[c]);
            }
        }
    
        public bool ContainsKey(T k)
        {
            return D.ContainsKey(k);
        }
    
        public U PopFirst()
        {
            var node = LL.First;
            LL.Remove(node);
            D.Remove(node.Value.Item2);
            return node.Value.Item1;
        }
    
        public int Count
        {
            get
            {
                return D.Count;
            }
        }
    }
    
    class LinkedHashMapTest 
    {
        public static void Test()
        {
            var lhm = new LinkedHashMap<char, int>();
    
            lhm['a'] = 1;
            lhm['b'] = 2;
            lhm['c'] = 3;
    
    
            Console.WriteLine(lhm['a']);
            Console.WriteLine(lhm['b']);
            Console.WriteLine(lhm['c']);
    
            Console.WriteLine(lhm.PopFirst());
            Console.WriteLine(lhm.PopFirst());
            Console.WriteLine(lhm.PopFirst());
        }
    }
