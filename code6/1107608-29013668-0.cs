    /// <summary>
        /// Find the changes in 
        /// </summary>
        /// <param name="input">The new Input XML which is saved in the databases</param>
        /// <param name="old">The old XML which was loaded at the start</param>
        /// <returns>only the diffrences in XML format</returns>
        public static String FindChanges(string input, string old)
        {
            bool returnEmpty = true;
            XDocument newXml = XDocument.Parse(input);
            XDocument returnXML = XDocument.Parse(input);
            XDocument oldXml = XDocument.Parse(old);
            foreach (XAttribute check in newXml.Root.Attributes())
            {
                if (check.Value == oldXml.Root.Attribute(check.Name).Value) returnXML.Root.Attribute(check.Name).Remove();
            }
            if (returnXML.Root.HasAttributes) returnEmpty = false;
            if (newXml.Root.HasElements)
            {
                foreach (XElement sub in newXml.Root.Elements())
                {
                    foreach (XAttribute check in sub.Attributes())
                    {
                        if (check.Value == oldXml.Root.Element(sub.Name).Attribute(check.Name).Value) returnXML.Root.Element(sub.Name).Attribute(check.Name).Remove();
                    }
                    if (!returnXML.Root.Element(sub.Name).HasAttributes) returnXML.Root.Element(sub.Name).Remove();
                    else returnEmpty = false;
                }
            }
            return returnEmpty? "" : returnXML.ToString();
        }
