    public static class Extensions
    {
        public static HtmlNode GetNodeByAttributeValue(this HtmlNode htmlNode, string attributeName, string attributeValue)
        {
            if (htmlNode.Attributes.Contains(attributeName))
            {
                if (string.Compare(htmlNode.Attributes[attributeName].Value, attributeValue, true) == 0)
                {
                    return htmlNode;
                }
            }
            foreach (var childHtmlNode in htmlNode.ChildNodes)
            {
                var resultNode = GetNodeByAttributeValue(childHtmlNode, attributeName, attributeValue);
                if (resultNode != null) return resultNode;
            }
            return null;
        }
    }
