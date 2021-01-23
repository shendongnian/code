        static void ModifyKeyValue(XDocument doc, int keyNumber, string newValue)
        {
            // XML fragment shows no namespace.  If your outer XML has a default namespace, replace "string.Empty" with it.
            var nameSpace = string.Empty;
            // Select XElement named "appSettings" in namespace "nameSpace".
            var appSettings = doc.Descendants(XName.Get("appSettings", nameSpace)).SingleOrDefault();
            if (appSettings == null)
                throw new InvalidOperationException(); // or create it?
            string keyValue = "key" + XmlConvert.ToString(keyNumber);
            // Select sub-elements of "appSettings" named "add" with attribute "key" named "keyValue".
            var elements = appSettings.Elements().Where(e => e.Name == XName.Get("add", nameSpace) && e.Attributes().Where(a => a.Name.LocalName == "key" && a.Value == keyValue).Any()).ToList();
            XElement element;
            if (elements.Count == 0)
            {
                // No element found with this key.  Add it.
                element = new XElement("add", new XAttribute("key", keyValue));
                appSettings.Add(element);
            }
            else if (elements.Count == 1)
            {
                element = elements[0];
            }
            else
            {
                throw new InvalidOperationException();
            }
            var attr = element.Attribute("value");
            if (attr == null)
                element.Add(new XAttribute("value", newValue));
            else
                attr.Value = newValue;
        }
