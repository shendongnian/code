    private static List<Product> ReadProductFile()
    {
        string productPath = GetDataDirectory("prod");
        if(!System.IO.File.Exists(productPath)) return null;
        var lst = new List<Product>();
        TextFieldParser parser = new TextFieldParser(productPath);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData) 
        {
            string[] fields = parser.ReadFields();
            foreach (string field in fields) 
            {
                try
                {
                    //assuming that the order of fields in the CSV file is the same as the 
                    //order of arguments of Product's constructor.
                    Product p = new Product(field[0], field[1], ...);
                    lst.Add(p);
                }
                catch(Exception ee)
                {
                    //Log error somewhere and continue with the rest of the CSV
                }
            }
        }
        parser.Close();
        return lst;
    }
