    using System;
    using Microsoft.Office.Interop.Word;
    namespace Word
    {
        class Program
        {
            static void Main(string[] args)
            {                
                Application wordApp = new Application();
                string filename = @"C:\test.doc";
                
                Document myDoc = wordApp.Documents.Open(filename);
                if (myDoc.Paragraphs.Count > 0)
                {
                    foreach (Paragraph p in myDoc.Paragraphs)
                    {
                        p.Range.Font.Name = "Calibri";
                        p.Range.Text = "I have changed this text I entered previously";
                    }
                }
                if (myDoc.Footnotes.Count > 0)
                {
                    foreach (Footnote fn in myDoc.Footnotes)
                    {
                        fn.Range.Font.Name = "Arial";
                    }
                }
                myDoc.Save();
                myDoc.Close();
                myDoc = null;
                wordApp.Quit();
                wordApp = null;
            }
        }
    }
