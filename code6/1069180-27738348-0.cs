    using System;
    using Microsoft.Office.Interop.Word;
    namespace Word
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application wordApp = new Application();
                Document myDoc = wordApp.Documents.Add();
                Paragraph para1 = myDoc.Content.Paragraphs.Add();
                para1.Range.Font.Name = "Arial";
                para1.Range.Text = "This is body of para1 with Arial font";
                if (myDoc.Sections.Count > 0)
                {
                    myDoc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Text = "This is footer in Calibri font";
                    myDoc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Font.Name = "Calibri";
                }
                myDoc.SaveAs(@"C:\test.doc");
                myDoc.Close();
                myDoc = null;
                wordApp.Quit();
                wordApp = null;
            }
        }
    }
