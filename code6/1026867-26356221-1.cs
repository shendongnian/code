    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
     
    public class Test {
        public static void Main() {
        // your code goes here
     
        var file_name = GetValidFileName("this is)file<ame.txt");
        Console.WriteLine(GetValidFileName(file_name));
     
        }
        private static string GetValidFileName(string fileName) {
            // remove any invalid character from the filename.
            String ret = Regex.Replace(fileName.Trim(), "[^A-Za-z0-9_. ]+", "")
            return ret.Replace(" ", String.Empty);
        }
    }
