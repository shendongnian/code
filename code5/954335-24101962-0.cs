    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main()  {
    string s1 = @"
    show database;
    insert into table_x values (""string;s"",""id_s"",1);
    insert into table2_x values (""s;s"",1);";
    var myRegex = new Regex(@"""[^""]*""|((?=;))");
    string replaced = myRegex.Replace(s1, delegate(Match m) {
        if (m.Groups[1].Value == "") return m.Value;
        else return "SplitHere";
        });
    string[] splits = Regex.Split(replaced,"SplitHere");
    foreach (string split in splits) Console.WriteLine(split);
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
