    public static bool Attribute(this XElement elem, string attributeName, bool defaultValue)
     {
       var toParse = (string)elem.Attribute(attributeName);
       bool result;
       if(Boolean.TryParse(toParse, out result))
       {
            return result;
       }
       return defaultValue;
     }
