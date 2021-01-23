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
                a.Add("keyA", "01:00");
                a.Add("keyB", "11:30");
                a.Add("keyC", "06:20");
                foreach (KeyValuePair<string, Reading> x in a)
                {
                    Console.WriteLine("{0}: {1}", x.Key, x.Value);
                }
            }
        }
    
        public class Cases : IEnumerable
        {
            private Dictionary<string, Reading> cases =
                new Dictionary<string, Reading>();
    
            IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return cases.GetEnumerator();
            }
    
            public bool Add(string caseCode, string scanTime)
            {
                Reading reading = new Reading(caseCode, scanTime);
                cases.Add(caseCode, reading);
                cases = cases.Values.OrderBy(v => v).ToDictionary(r => r.caseCode);
                return true;         
            }
        }
    
        public class Reading : IComparable
        {
            public string caseCode; // don't mind public fields and bad naming, it's just an example ;)
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
    
            public override string ToString()
            {
                return caseCode + " scanned at " + scanTime;
            }
        }
    }
