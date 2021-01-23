        private static void RecParseXDoc(XElement element, Dictionary<string, string> xDict)
        {
            if (element.HasElements)
            {
                foreach (var childElement in element.Elements())
                {
                    RecParseXDoc(childElement, xDict);
                }
                
            }
            xDict.Add(element.Name.ToString(), element.Value);
        }
