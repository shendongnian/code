    // Add Microsoft.VisualBasic.dll to References.
    using Microsoft.VisualBasic.FileIO; 
    // input is your original line from csv.
    // Remove starting and ending quotes.
    input = input.Remove(0, 1);
    input = input.Remove(input.Length - 1);
    // Replace double quotes with single quotes.
    input = input.Replace("\"\"", "\"");
    
    string[] result;
    using (var csvParser = new TextFieldParser(new StringReader(input)))
    {
        csvParser.Delimiters = new string[] { "," };
        result = csvParser.ReadFields();
    }   
