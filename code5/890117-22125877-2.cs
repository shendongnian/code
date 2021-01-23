    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
    		string command = "<CP1><SSA1>";
    		string command_2 = "<CP1><MPS>";
    
    		prnt(command);
    		prnt(command_2);
                //prnt(command+command_2); //even this will work :)
        }
        
        private static void prnt(string str)
        {
        			List<string> l = ExtractFromString(str,"<",">");
    		foreach(string ll in l)
    			Console.WriteLine(ll.Replace("SSA",""));
        }
        
        private static List<string> ExtractFromString(string text, string start, string end)
        {            
            List<string> Matched = new List<string>();
            int index_start = 0, index_end=0;
            bool exit = false;
            while(!exit)
            {
                index_start = text.IndexOf(start);
                index_end = text.IndexOf(end);
                if (index_start != -1 && index_end != -1)
                {
                    Matched.Add(text.Substring(index_start + start.Length, index_end - index_start - start.Length));
                    text = text.Substring(index_end + end.Length);
                }
                else
                    exit = true;
            }
            return Matched;
        }
    }
