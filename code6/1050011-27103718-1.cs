    // Add Microsoft.VisualBasic.dll to References.
    using Microsoft.VisualBasic.FileIO; 
    
    string[] result;
    using (var csvParser = new TextFieldParser(new StringReader(input)))
    {
        csvParser.HasFieldsEnclosedInQuotes = false;
        csvParser.Delimiters = new string[] { "," };
        result = csvParser.ReadFields();
    }   
