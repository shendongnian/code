          IEnumerable<XElement> xx = xdoc.Root.Descendants().Elements().Where(c => { if (c.Name == "name") { c.Value = "Dell"; } else if (c.Name == "details") { c.Value = "Dell Detial"; } return true; }).Select(c => c);
    
    
                // Loop.
                string x = string.Empty;
                foreach (XElement x1 in xx)
                {
                    x += x1.ToString();
                }
          Console.WriteLine(x.ToString());
