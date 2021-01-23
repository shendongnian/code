    using (var parser = new TextFieldParser(@"Path"))
    {
        parser.HasFieldsEnclosedInQuotes = false;
        parser.Delimiters = new[]{","};
        while(parser.PeekChars(1) != null)
        {
            string[] fields = parser.ReadFields();
        }
    }
