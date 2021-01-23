    string myText = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
    var resultString = Regex.Replace(myText, @"( |\r?\n)\1+", "$1");
    MemoryStream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(resultString));
    richTextBox.SelectAll();
    richTextBox.Selection.Load(stream, DataFormats.Text);
