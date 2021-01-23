    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    
    namespace MyNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var document = WordprocessingDocument.Create(
                    "test.docx", WordprocessingDocumentType.Document))
                {
                    document.AddMainDocumentPart();
                    document.MainDocumentPart.Document = new Document(
                        new Body(new Paragraph(new Run(new Text("some text")))));
                }
            }
        }
    }
