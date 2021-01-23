        private static void Test_Namespace_Error(bool doAnError)
        {
            XDocument xDoc = new XDocument();
            string ns = "http://mynamespace.com";
            XElement xEl = null;
            if (doAnError)
            {
                // WRONG: This creates an element with no namespace and then changes the namespace
                xEl = new XElement("tagName", new XAttribute("xmlns", ns));
            }
            else
            {
                // RIGHT: This creates an element in a namespace, and implicitly adds an xmlns tag
                XNamespace xNs = ns;
                xEl = new XElement(xNs + "tagName");
            }
            xDoc.Add(xEl);
            Console.WriteLine(xDoc.ToString());
        }
