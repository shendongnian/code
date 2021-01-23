    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
         string word = "pencil";
         string finalWord = word.Substring(0, 3).ToUpper() + word.Substring(3);
         Console.WriteLine(finalWord); //PENcil
        }
    }
