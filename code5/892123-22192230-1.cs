     public static IEnumerable<string> GetTemplateNames(string xsltPath)
            {
                var xsl = XElement.Load(xsltPath);
                return xsl.Elements("{http://www.w3.org/1999/XSL/Transform}template")
                    .Where(temp => temp.Attribute("name") != null)
                    .Select(temp => temp.Attribute("name").Value);
            }
