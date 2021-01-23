    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    
        static void Main()
        {
        string s1 = @"on Apr 28, 2014 at 22:00
    an Employee John Doe accessed
    server - TPCX123
    AccessType2 was ReasonType1 - program: Px2x3x, start: No22, 0.0 sec";
    
        try
        {
        var myRegex = new Regex(@"(?s)^on\s+([\w, ]+?) at (\d{2}:\d{2}).*?Employee ([\w ]+) accessed.*?server - (\w+).*?(\w+) was (\w+) - program: (\w+), start: (\w+), (\d+\.\d+ \w+)");
        string date = myRegex.Match(s1).Groups[1].Value;
        string time = myRegex.Match(s1).Groups[2].Value;
        string name = myRegex.Match(s1).Groups[3].Value;
        string server = myRegex.Match(s1).Groups[4].Value;
        string access = myRegex.Match(s1).Groups[5].Value;
        string reason = myRegex.Match(s1).Groups[6].Value;
        string prog = myRegex.Match(s1).Groups[7].Value;
        string start = myRegex.Match(s1).Groups[8].Value;
        string length = myRegex.Match(s1).Groups[9].Value;
        Console.WriteLine("ReportDate = " + date);
        Console.WriteLine("ReportTime = " + time);
        Console.WriteLine("EmployeeName = " + name);
        Console.WriteLine("ServerName = " + server);
        Console.WriteLine("AccessType = " + access);
        Console.WriteLine("ReasonType = " + reason);
        Console.WriteLine("ProgramId = " + prog);
        Console.WriteLine("Start = " + start);
        Console.WriteLine("Length = " + length);
        }
        catch (ArgumentException ex)
        {
        // We have a syntax error
        }
    
        Console.WriteLine("\nPress Any Key to Exit.");
        Console.ReadKey();
        } // END Main
    } // END Program
