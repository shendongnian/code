    public static class XmlNodeExtensions
    {
        /// <summary>
        /// Copy all child XmlNodes from the source to the destination.
        /// </summary>
        /// <param name="source">Copy children FROM this XmlNode</param>
        /// <param name="destination">Copy children TO this XmlNode</param>
        public static void CopyChildren(this XmlNode source, XmlNode destination)
        {
            if (source == null || destination == null)
                throw new ArgumentNullException();
            var doc = destination.OwnerDocument;
            if (doc == null)
                throw new InvalidOperationException("null document");
            // Clone the array to prevent infinite loops when the two nodes are from the same document.
            foreach (var child in source.ChildNodes.Cast<XmlNode>().ToArray())
            {
                var copy = doc.ImportNode(child, true);
                destination.AppendChild(copy);
            }
        }
    }
