    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            Regex r = new Regex("^(?<first>PO|P|S|[1-5])(?<second>VP|GZ|GAR|PP|NAD|TER|NT|OT|LO)?$");
            Match match = r.Match("PO");
            
            for (int i = 0; i < match.Groups.Count; i++) {
                Console.WriteLine(string.Format("{0}: {1}; {2}", i, match.Groups[i].Success, match.Groups[i].Value));
            }
        }
    }
