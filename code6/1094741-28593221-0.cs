    private static void replaceHyperlinksInShapes()
    {
        Word.Application app = new Word.Application();
        Word.Document doc = app.Documents.Open(FileName: @"e:\Temp\demoFile.docx");
        Word.Hyperlinks links = doc.Hyperlinks;
        Debug.WriteLine("Text Hyperlinks");
        foreach (var hyperlink in links)
        {
            string address = ((Microsoft.Office.Interop.Word.Hyperlink)hyperlink).Address;
            Debug.WriteLine("\t" + address);
        }
        Word.Shapes shapes = doc.Shapes;
        Debug.WriteLine("Shape Hyperlinks");
        foreach (Word.Shape shape in shapes)
        {
            Word.TextFrame frame = shape.TextFrame;
            Word.Range range = frame.TextRange;
            foreach (var hyperlink in range.Hyperlinks)
            {
                string address = ((Word.Hyperlink)hyperlink).Address;
                Debug.WriteLine("\t" + address);
            }
        }
    }
