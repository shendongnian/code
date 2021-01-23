    using(MemoryStream stream = new MemoryStream())
    using(StreamWriter writer = new StreamWriter(stream))
    {
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
    
        using(TextFieldParser parser = new TextFieldParser(stream)){
            parser.TextFieldType = FieldType.Delimited;
            parser.Delimiters = new string[] {","};
            parser.HasFieldsEnclosedInQuotes = true;
    
            while(!parser.EndOfData){ //Loop through lines until we reach the end of the file
                string[] fields = parser.ReadFields(); //This will contain your fields
            }
        }
    }
