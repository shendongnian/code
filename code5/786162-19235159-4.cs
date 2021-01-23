    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestProject
    {
        public class NoCompare
        {
            public string V
            {
                get;
                set;
            }
        }
        public class Compare : IComparable
        {
            public string V
            {
                get;
                set;
            }
            public int CompareTo(object obj)
            {
                NoCompare a = obj as NoCompare;
                if (a == null)
                    return -1;
                return String.Compare(V, a.V);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                NoCompare[] strings = new NoCompare[] { new NoCompare() { V = "a" }, new NoCompare() { V = "b" }, new NoCompare() { V = "c" } };
    
                Compare t = new Compare();
                t.V = "b";
                Array.BinarySearch((object[])strings, t);
           }
        }
    }
