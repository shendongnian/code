            // using LINQ
            var xdoc = XDocument.Parse(XML);
            
            var subtypes = xdoc.Descendants("Level1").Descendants("Subtype");
            Console.WriteLine("LINQ Level1 Subtype");
            foreach (var el in subtypes)
            {
                Console.WriteLine(el.Value);
            }
            var paths = xdoc.Descendants("Level4").Descendants("L4Node").Attributes("path");
            Console.WriteLine("LINQ Level4 Path");
            foreach (var el in paths)
            {
                Console.WriteLine(el.Value);
            }
