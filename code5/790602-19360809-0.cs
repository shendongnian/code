    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load("XMLFile1.xml");
            var selection = new XElement("Selection");
            var table = new XElement("Table");
            table.Add(new XAttribute("Name", "Query2"));
            var columns = new XElement("Columns");
            var column = new XElement("Column");
            column.Add(new XAttribute("Name", "PName"));
            columns.Add(column);
            column = new XElement("Column");
            column.Add(new XAttribute("Name", "Prog"));
            columns.Add(column);
            column = new XElement("Column");
            column.Add(new XAttribute("Name", "RDate"));
            columns.Add(column);
            table.Add(columns);
            selection.Add(table);
            var dataProvider = doc.Root.Descendants("DataProvider").First();
            dataProvider.Add(selection);
            doc.Save("XMLFile2.xml");
        }
    }
