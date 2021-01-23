    public static class Helpers
    {
       public static string TryGetInnerXml(this XmlNode node, string innerNodeName)
       {
         string innerXml = "";
         XmlNode innerNode = node.SelectSingleNode(innerNodeName);
         if (innerNode != null)
         {
         innerXml = innerNode.InnerXml;
         }
         return innerXml;
       }
    }
