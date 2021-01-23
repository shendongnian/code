        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Parse(System.IO.File.ReadAllText("F:\\save.xml"));
            xdoc.Descendants().All(m => { Replace(m); return true; });
            Console.Write(xdoc.ToString());
            Console.Read();
        }
        static void Replace(XElement node)
        {
            if (node.Name.LocalName.IndexOf("-") > -1)
            {
                node.Name = node.Name.LocalName.Replace('-', '_');
            }
            node.Attributes().All(m => { Replace(m); return true;});
        }
        static void Replace(XAttribute node)
        {
            if (node.Name.LocalName.IndexOf("-") > -1)
            {
                XAttribute xa = new XAttribute(node.Name.LocalName.Replace('-', '_'), node.Value);
                node.Parent.Add(xa);
                node.Remove();
            }
        }
