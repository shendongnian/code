        string GetAttributesString(XElement element)
        {
            if(element == null || !element.HasAttributes)
                return string.Empty;
            string format = " {0}={1}";
            StringBuider result = new StringBuilder();
            foreach(var attribute in element.Attributes())
            {
                result.AppendFormat(format, attribute.Name, attribute.Value);
            }
            return result.ToString();
        }
