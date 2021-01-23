    String path = @"D:\CSV\data.csv";
    
    using (TextFieldParser parser = new TextFieldParser(path))
    {
        parser.SetDelimiters(new string[] { "," });
        parser.HasFieldsEnclosedInQuotes = true;
     
        // if you want to skip over header line., uncomment line below
        // parser.ReadLine();
     
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();
            column1 = fields[0];
            column2 = fields[1];
            column3 = int.Parse(fields[2]);
            column4 = double.Parse(fields[3]);
        }
    }
