    using System;
    using Microsoft.Office.Interop.Word;
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                var wordApp = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                var words = wordApp.ActiveDocument.Words;
                foreach (Range word in words)
                {
                    Console.WriteLine(word.Text);
                }
            }
        }
    }
