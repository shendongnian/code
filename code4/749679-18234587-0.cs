    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    using Word = Microsoft.Office.Interop.Word;
    
    namespace OpenXMLSDKTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Open XML Method
                object fileName = @"OpenXmlTest.docx";
                using (WordprocessingDocument myDocument = WordprocessingDocument.Open(fileName.ToString(), true))
                {
                    var textbox = myDocument.MainDocumentPart.Document.Descendants<TextBoxContent>().First();
                    Console.WriteLine(textbox.InnerText);
                }
    
                // Office Interop Method
                object missing = System.Reflection.Missing.Value;
                object readOnly = false;
                object isVisible = true;
    
                Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref  missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                object firstShape = 1;
                string textFrameText = wordApp.ActiveDocument.Shapes.get_Item(ref firstShape).TextFrame.TextRange.Text;
                wordApp.Quit(ref missing, ref missing, ref missing);
    
                Console.WriteLine(textFrameText);
    
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
