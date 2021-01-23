    using System.Linq
    using System.Collections.Generic;
    public class WordFinder
    {
        private static bool FindWordInLines(string word_to_find, string[] lines)
        {
            foreach(var line in lines)
            {
                 if(line.Contains(word_to_find)
                    return true;
            }
            return false;
        }  
        public string SearchForWordsInFile(string path, string sentence)
        {
             // https://msdn.microsoft.com/en-us/library/s2tte0y1(v=vs.110).aspx
             var lines = System.IO.File.ReadAllLines(path);
             var words = .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 
             var result = string.Empty;
             foreach(var word in words)
             {
                 var found = FindWordInLines(word, lines);
                 // {{ in string.Format outputs {
                 // }} in string.Format outputs }
                 // {0} says use first parameter's ToString() method
                 result += string.Format("{{{0}}}", found);
             }
             return result;
        }
    }
