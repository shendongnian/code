    // Add Microsoft.VisualBasic.dll to References.
    using Microsoft.VisualBasic.FileIO; 
    var input = @"123,456,""Hello World"",789,""This string has a comma , in it"",0";
    
    string[] result;
    using (var csvParser = new TextFieldParser(new StringReader(input)))
    {
        csvParser.Delimiters = new string[] { "," };
        result = csvParser.ReadFields();
    }
    
    foreach (var entry in result)
        Console.WriteLine(entry);
