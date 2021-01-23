    private Paragraph paragraph = new Paragraph();
    _rtbDocument = new FlowDocument(paragraph);
    public void WriteMessage(string output)
        {
            string outputFormat = string.Format("{0}", output);
            string[] parts = output.Split(new char[]{':'}, 2);
            string user = parts[0];
            string[] username = parts[0].Split('!');
            Paragraph newline = new Paragraph();
            newline.LineHeight = 2;
            newline.Inlines.Add(new Run(username[0].Trim() + ": ") { Foreground = UserColor });
            newline.Inlines.Add(new Run(parts[1]) { Foreground = MessageColor });
            
            _rtbDocument.Blocks.Add(newline);
            
            if (_rtbDocument.Blocks.Count > 10) 
                { 
                   _rtbDocument.Blocks.Remove(_rtbDocument.Blocks.FirstBlock); 
                }
    }
