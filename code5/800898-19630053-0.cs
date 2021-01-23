    using (var parser = new TextFieldParser("test.csv"))
    {
        parser.CommentTokens = new string[] { "#" };
        parser.SetDelimiters(new string[] { ";" });
        parser.HasFieldsEnclosedInQuotes = true;
        // Skip over header line.
        parser.ReadLine();
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();
            Console.WriteLine("{0} {1} {2}", fields[0], fields[1], fields[2]);
        }
    }
