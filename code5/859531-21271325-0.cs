    TextRange t = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
    using (FileStream file = new FileStream(fileLocation, FileMode.Create))
    {
        t.Save(file, System.Windows.DataFormats.Rtf);
    }
