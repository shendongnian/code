        public string FindValueFromText(XDocument xdoc, string str)
        {
            while (str != "")
            {
                var h = xdoc.Root.Elements("ingredient").FirstOrDefault(u => u.Value == str);
                if (h == null)
                {
                    str = str.Remove(str.LastIndexOf(" "));
                    FindValueFromText(xdoc, str); //recursive
                }
                else 
                {
                    return h.Attribute("value").Value;
                }
            }
            return "Not found value";
        }
