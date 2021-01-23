    // This will extract the contents of a word doc and place them in an IEnumerable
    // covering your first problem
    private IEnumerable<string> ExtractContents(string filePath)
    {
        using (var stream = File.Open(filePath, FileMode.Open))
        using (var document = WordprocessingDocument.Open(stream, true))
        {
            string content = document.MainDocumentPart.Document.Body.InnerText;
            return content.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        }
    } 
