       var doc = XDocument.Load(@"C:\TestCases\test.xml");
            foreach (var node in doc.Descendants().Where(x => "CIName Type Status FriendlyName AccountNo".Contains(x.Name.LocalName)))
            {
                Console.WriteLine(string.Format("{0}:{1}", node.Name.LocalName, node.Value));
            }
