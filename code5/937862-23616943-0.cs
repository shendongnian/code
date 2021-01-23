         private static string ElementType(IType type, bool isEnumerable = false)
        {
            string text = string.Empty;
            if (type == null)
            {
                text = "object";
            }
            else 
            {
                text = TypeName(type);
            }
    
            if(!string.IsNullOrWhiteSpace(text) && isEnumerable)
            {
               //SO Change IEnumerable to IList here
                text = "IEnumerable<" + text + ">";
            }
    
            return text;
        }
