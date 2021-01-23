    using System.Collections;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                Cases a = new Cases();
                a.Add("keyA", "c");
                a.Add("keyB", "b");
                a.Add("keyC", "a");
                foreach (KeyValuePair<string, Reading> x in a)
                {
                    Console.WriteLine(x);
                }
            }
        }
    
        public class Cases : IEnumerable
        {
            private Dictionary<string, Reading> cases =
                new Dictionary<string, Reading>();
    
            IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                foreach (KeyValuePair<string, Reading> entry in cases.OrderBy(kvp => kvp.Value))
                {
                    yield return entry;
                }
            }
    
            public bool Add(string caseCode, string scanTime)
            {
                Reading reading = new Reading(caseCode, scanTime);
                cases.Add(caseCode, reading);
                cases = cases.Values.OrderBy(v => v).ToDictionary(r => r.scanTime);
                return true;         
            }
    
            private class SortBarCodeAscending : IComparer<Reading>
            {
                public int Compare(Reading x, Reading y)
                {
                    return string.Compare(x.scanTime, y.scanTime);
                }
            }
        }
    
        public class Reading : IComparable
        {
            public string caseCode;
            public string scanTime;
            public Reading(string a, string b)
            {
                this.caseCode = a;
                this.scanTime = b;
            }
    
            public int CompareTo(object obj)
            {
                Reading other = obj as Reading;
                if (other == null)
                {
                    return -1;
                }
    
                return this.scanTime.CompareTo(other.scanTime);
            }
        }
    }
