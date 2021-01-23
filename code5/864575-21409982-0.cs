    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s =
                    @"USERNAME: ADMIN|00004|GI FILE: Lorem ipsum dolor sit amet1.docx DETAIL:There was no endpoint listening at http://localhost:5557/";
                  var str =  s.SkipUntilWord("DETAIL:");
            }
    
        }
        public static class MyExtensions
        {
            public static string SkipUntilWord(this String str,string word)
            {
                return str.Substring(str.IndexOf(word,StringComparison.CurrentCulture) + word.Length);
            }
        }   
