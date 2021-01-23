    using System.Collections;
    using System.Collections.Generic;
    using System;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                Cases a = new Cases();
                a.Add("aa", "x");
                a.Add("xd", "x");
                a.Add("ea2", "x");
                foreach (KeyValuePair<string, Reading> x in a)
                {
                    Console.WriteLine(x); // prints the pairs according to keys sorted alphabetically
                }
            }
        }
    
        public class Cases : IEnumerable
        {
            private SortedDictionary<string, Reading> cases =
                new SortedDictionary<string, Reading>(new SortBarCodeAscending());
    
            IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return cases.GetEnumerator();
            }
    
            public bool Add(string caseCode, string scanTime)
            {
                Reading reading = new Reading(caseCode, scanTime);
                cases.Add(caseCode, reading);
                return true;         
            }
    
            private class SortBarCodeAscending : IComparer<string>
            {
                public int Compare(string x, string y)
                {
                    return string.Compare(x, y);
                }
            }
        }
    
        public class Reading
        {
            string a;
            string b;
            public Reading(string a, string b)
            {
                this.a = a;
                this.b = b;
            }
        }
    }
