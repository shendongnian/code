    using System;
    using System.Text.RegularExpressions;
    class Program {
    static void Main() {
    
    string s1 = "<tr class=\"discussion r0\"><td class=\"topic starter\"><a href=\"SITE?d=6638\">Test di matematica</a></td>";
    var r = new Regex(@"(?i)<tr[^>]*?>\s*<td[^>]*?>\s*<a[^>]*?>([^<]*)<", RegexOptions.IgnoreCase);
    string capture = r.Match(s1).Groups[1].Value;
    Console.WriteLine(capture);
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
