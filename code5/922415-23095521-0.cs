    using System.Text.RegularExpressions;
    using System;
    
    public class Program{
        public static void Main(string[] args) {
            string v = "hello";
            char[] d = v.ToCharArray();
    
            // Convert into the a string array, the old-fashioned way.
            string[] name = new string[d.Length];
            for (int i = 0; i < d.Length; i++)
                name[i] = d[i] + ""; 
    
            Console.WriteLine(string.Join(" ",name));
        }
    }
