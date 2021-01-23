    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            var input = "\\DF3\\root\\cimv2:Win32_Group.Domain=\"DF3\",Name=\"Administrators\"";
            Console.WriteLine(Regex.Match(input, "Name=\\\"(.*?)\\\"").Groups[1].Value);
        }
    }
