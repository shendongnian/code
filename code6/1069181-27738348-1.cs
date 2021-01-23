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
                //Document myDoc = wordApp.Documents.Add();
                //Paragraph para1 = myDoc.Content.Paragraphs.Add();
                //para1.Range.Font.Name = "Arial";
                //para1.Range.Text = "This is body of para1 with Arial font";
                //if (myDoc.Sections.Count > 0)
                //{
                //    myDoc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Text = "This is footer in Calibri font";
                //    myDoc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Font.Name = "Calibri";
                //}
                //myDoc.SaveAs(@"C:\test.doc");
                //myDoc.Close();
                //myDoc = null;
                //wordApp.Quit();
                //wordApp = null;
                Document myDoc = wordApp.Documents.Open(filename);
                Paragraphs myParas = myDoc.Paragraphs;
                foreach (Paragraph p in myParas)
                {
                    p.Range.Font.Name = "Calibri";
                    p.Range.Text = "I have changed this text I entered previously";
                }
                if (myDoc.Sections.Count > 0)
                {
                    myDoc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Font.Name = "Arial";
                    myDoc.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Text = "Footer font has been changed to Arial";
                }
                myDoc.Save();
                myDoc.Close();
                myDoc = null;
                wordApp.Quit();
                wordApp = null;
            }
        }
    }
