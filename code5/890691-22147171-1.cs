    public class Parser
    {
        public List<Dictionary<string, object>> Parse(XElement root)
        {
            var result = new List<Dictionary<string, object>>();
            foreach (var e in root.Elements())
            {
                if (e.Name == "dict")
                {
                    result.Add(ParseDict(e));
                }
            }
            return result;
        }
        private Dictionary<string, object> ParseDict(XElement element)
        {
            var dict = new Dictionary<string, object>();
            foreach (var subelement in element.Elements())
            {
                if (subelement.Name == "key")
                {
                    dict.Add(subelement.Value, ParseValue(subelement.ElementsAfterSelf().First()));        
                }
            }
            return dict;
        }
        private object ParseValue(XElement valueElement)
        {
            if (valueElement.Name == "string")
            {
                return valueElement.Value;
            }
            if (valueElement.Name == "array")
            {
                return new List<object>(valueElement.Elements().Select(e => ParseValue(e)));
            }
            if (valueElement.Name == "dict")
            {
                return ParseDict(valueElement);
            }
            if (valueElement.Name == "true")
            {
                return true;
            }
            if (valueElement.Name == "false")
            {
                return false;
            }
            return null;
        }
    }
