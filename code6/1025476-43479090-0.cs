    // Open a WordprocessingDocument for editing using the filepath.
    using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(filepath, true))
    {
     //itenerate throught text
     foreach (var text in body.Descendants<Text>())
     {
       text.Parent.Append(new Text("Text:"));
       text.Parent.Append(new Break());
       text.Parent.Append(new Text("Text"));
     }
    }
