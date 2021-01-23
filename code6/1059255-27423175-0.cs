    private static void RemoveNils(XElement elem)
    {
            string nilNamespace = "{http://www.w3.org/2001/XMLSchema-instance}nil";
            //first condition should be enough, the rest are just fail-safes
            if (elem.Attributes().Any(name => name.Name == nilNamespace) && elem.Elements().Count() == 0 && elem.IsEmpty)
            {
                elem.Attributes().Remove();
                return;
            }
            foreach (XElement el in elem.Elements())
                RemoveNils(el);
    }
