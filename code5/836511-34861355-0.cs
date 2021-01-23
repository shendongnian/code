    using DocumentFormat.OpenXml.Packaging;
    using OpenXmlPowerTools;
    using System.IO;
    
    namespace SearchAndReplace
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open("Test01.docx", true))
                    TextReplacer.SearchAndReplace(wordDoc:doc, search:"the", replace:"this", matchCase:false);
            }
        }
    }
