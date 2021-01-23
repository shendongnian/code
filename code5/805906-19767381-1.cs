    public static TryGetInnerText(this XmlElement root, string childName, out string text){
         if(root.GetElementsByTagName(childName).Count > 0){
               text = root.GetElementsByTagName(childName)[0].InnerText;
               return true;
         }
         text = null;
         return false;
    }
