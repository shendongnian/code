    using Microsoft.VisualBasic.FileIO.TextFieldParser;
    
    var parser = new TextFieldParser("mycsvfile.csv");
    parser.HasFieldsEnclosedInQuotes = true;
    parser.SetDelimiters(",");
    
    string[] fields;
    
    while (!parser.EndOfData)
    {
        fields = parser.ReadFields();
        foreach (string field in fields)
        {
            Console.WriteLine(field);
        }
    } 
    parser.Close();
