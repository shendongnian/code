    class Program
    {
        static void Main(string[] args)
        {
            var output = new XmlDocument();
            output.AppendChild(output.CreateXmlDeclaration("1.0", "utf-8", null));
            var xmlns = new XmlNamespaceManager(output.NameTable);
            var root = output.CreateElement("ps", "report", "http://example.com/namespace/ps");
            var list = output.CreateElement("ps", "results", "http://example.com/namespace/ps");
            list.Attributes.Append(output.CreateAttribute("Identifikation"));
            list.Attributes[0].Value = "999999";
            root.AppendChild(list);
            var item = output.CreateElement("ps", "result", "http://example.com/namespace/ps");
            item.Attributes.Append(output.CreateAttribute("id"));
            item.Attributes[0].Value = "11125";
            list.AppendChild(item);
            //TODO: Append more validation messages.
            output.AppendChild(root);
            output.WriteTo(new XmlTextWriter(Console.Out));
            System.Console.ReadLine();
        }
    }
