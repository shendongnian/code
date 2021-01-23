    public static bool TryGetInnerText(this XmlElement root, string childName, out string text)
        {
             var children = root.GetElementsByTagName(childName);
             if(children.Count > 0){
                   text = children[0].InnerText;
                   return true;
             }
             text = null;
             return false;
        }
