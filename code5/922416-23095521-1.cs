    using System.Text.RegularExpressions;
    using System;
    
    public class Program{
        public static void Main(string[] args) {
            string v = "hello";
            // Convert into the a string array, the old-fashioned way.
            string[] name = new string[v.Length];
            for (int i = 0; i < v.Length; i++)
            name[i] = v[i] + ""; 
    
            string feedToPermutationFunction = string.Join(" ",name));
            // Feed the above string into your permutation code.
        }
    }
