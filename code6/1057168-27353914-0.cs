    public class Product
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class ReadAndWrite
    {
        var productList = new List<Product>();
        using(XmlReader reader = XmlReader.Create("path/to/file"))
        {
            while(reader.Read())
            {
                //Add products to list
            }
        }
        var duplicates = productList.GroupBy(p => p.Code).Where(x => x.Count() > 1).SelectMany(v => v).ToList();
        
        using(XmlWriter writer = XmlWriter.Create("path/to/dupes.xml"))
        {
            foreach(var duplicate in duplicates)
            {
                //Write to the duplicate file
            }
        }
    }
