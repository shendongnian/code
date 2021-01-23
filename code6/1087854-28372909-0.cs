        static void ModifyKeyValue(XDocument doc, int keyNumber, string newValue)
        {
            // XML fragment shows no namespace.  If your outer XML has a namespace, replace "string.Empty" with it.
            var namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace("ns", string.Empty);
            // Select XElement named "appSettings" in default namespace
            var appSettings = doc.XPathSelectElement("ns:appSettings", namespaceManager);
            if (appSettings == null)
                throw new InvalidOperationException(); // or create it?
            string keyValue = "key" + XmlConvert.ToString(keyNumber);
            string query = "./ns:add[@key='" + keyValue + "']";
            // Select elements named "add" with attribute "key" named "keyValue".
            var elements = appSettings.XPathSelectElements(query, namespaceManager).ToList();
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
