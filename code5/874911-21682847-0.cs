    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication25
    {
        class Program
        {
            static void Main()
            {
                string instanceName = "message read rate [ process id 1776 ]";
    
                Regex expression = new Regex(@"process id (\d+)");
                var matches = expression.Match(instanceName);
                
                if (matches.Success)
                {
                    Console.WriteLine("Process ID: " + matches.Groups[1].Value);
                }
                else
                {
                    Console.WriteLine("No match found");
                } 
            }
        }
    }
