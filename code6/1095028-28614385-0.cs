            System.Xml.Linq.XDocument docNew = System.Xml.Linq.XDocument.Parse(doc);
            var elements = docNew.Root.Descendants();
            foreach (var element in elements)
            {
                var textValue = string.Concat(element.Nodes().OfType<System.Xml.Linq.XText>().Select(tx => tx.Value));
                Console.WriteLine(string.Format("{0}: {1}", element.Name.ToString(), textValue));
            }
