            var doc = XDocument.Parse(xml);
            foreach (var element in doc.Descendants())
            {
                if (element.Name.LocalName.Contains("-"))
                {
                    var newName = element.Name.LocalName.Replace('-', '_');
                    element.Name = element.Name.Namespace + newName;
                }
                var list = element.Attributes().ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    var attr = list[i];
                    if (attr.Name.LocalName.Contains("-"))
                    {
                        XAttribute newAttr = new XAttribute(attr.Name.Namespace + attr.Name.LocalName.Replace('-', '_'), attr.Value);
                        list[i] = newAttr;
                    }
                }
                element.ReplaceAttributes(list);
            }
