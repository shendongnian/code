    /// entry point - will look for hyperlinks in text
    /// and afterwards in shapes within this document
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
        Debug.WriteLine("Shape Hyperlinks");
        foreach (Word.Shape shape in doc.Shapes)
        {
            searchForHyperLink(shape);
        }
    }
    /// will search for hyperlinks in given shape
    /// if this shape is a group, call recursivly
    private static void searchForHyperLink(Word.Shape shape)
    {
        /// check if this shape is a group or not
        /// CRUCIAL!!! There are way more types which may contain hyperlinks
        /// check if necessary
        if (shape.Type == Office.MsoShapeType.msoAutoShape)
        {
            Word.TextFrame frame = shape.TextFrame;
            Word.Range range = frame.TextRange;
            if (range != null)
            {
                foreach (var hyperlink in range.Hyperlinks)
                {
                    string address = ((Word.Hyperlink)hyperlink).Address;
                    Debug.WriteLine("\t" + address);
                }
            }
        }
        else if (shape.Type == Office.MsoShapeType.msoGroup)
        {
            for (int i = 1; i <= shape.GroupItems.Count; i++)
            {
                Word.Shape childShape = shape.GroupItems[i];
                searchForHyperLink(childShape);
            }
        }
    }
