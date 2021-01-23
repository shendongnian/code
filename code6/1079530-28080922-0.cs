    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Spire.Doc;
    
    namespace Xml2Pdf
    {
        class Program
        {
            static void Main(string[] args)
            {
                Document doc = new Document();
                doc.LoadFromFile("sample.html", FileFormat.Html);
                doc.SaveToFile("test.xml", FileFormat.Xml);
            }
        }
    }
