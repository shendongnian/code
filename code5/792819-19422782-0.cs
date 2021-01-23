    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Microsoft.Office.Interop.Word;
    
    namespace Word
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fileName = @"C:\Scratch\test.docx";
    
                var app = new Application();
                app.Visible = true;
    
                var doc = app.Documents.Open(fileName);
    
                var rng = doc.Range();
    
                // This is the bit relevant to the question
                rng.Find.Text = "it";
                rng.Find.MatchCase = false;
    
                while (rng.Find.Execute(Forward: true))
                {
                    rng.Font.Bold = 1;
                    rng.HighlightColorIndex = WdColorIndex.wdDarkRed;
                }
            }
        }
    }
