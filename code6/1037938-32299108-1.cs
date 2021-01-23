    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Codility
    {
        internal class Program
        {
            public struct Indice
            {
                public Indice(int p, int q)
                {
                    P = p;
                    Q = q;
                }
                public int P;
                public int Q;
                public override string ToString()
                {
                    return string.Format("({0}, {1})", P, Q);
                }
            }
            private static void Main(string[] args)
            {
                //                      0 1 2 3 4 5 
                int[] list = new int[] {3,3,3,3,3,3};
                int answer = GetPairCount(list);
                Console.WriteLine("answer = " + answer);
                Console.ReadLine();
            }
            private static int GetPairCount(int[] A)
            {
                if (A.Length < 2) return 0;
                Dictionary<int, Dictionary<Indice, Indice>> tracker = new Dictionary<int, Dictionary<Indice, Indice>>();
                for (int i = 0; i < A.Length; i++)
                {
                    int val = A[i];
                    if (!tracker.ContainsKey(val))
                    {
                        Dictionary<Indice, Indice> list = new Dictionary<Indice, Indice>();
                        Indice seed = new Indice(i, -1);
                        list.Add(seed, seed);
                        tracker.Add(val, list);
                    }
                    else
                    {
                        Dictionary<Indice, Indice> list = tracker[val];
                        foreach (KeyValuePair<Indice,Indice> item in list.ToList())
                        {
                            Indice left = new Indice(item.Value.P, i);
                            Indice right = new Indice(i, item.Value.Q);
                            if (!list.ContainsKey(left))
                            {
                                list.Add(left, left);
                                Console.WriteLine("left= " + left);
                            }
                            if (!list.ContainsKey(right))
                            {
                                list.Add(right, right);
                                Console.WriteLine("\t\tright= " + right);
                            }
                        }
                    }
                }
                return tracker.SelectMany(kvp => kvp.Value).Count(num => num.Value.Q > num.Value.P);
            }
        }
    }
