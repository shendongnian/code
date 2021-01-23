    public static class XmlNodeExtensions
    {
        public static XmlDocument Document(this XmlNode node)
        {
            for (; node != null; node = node.ParentNode)
            {
                var doc = node as XmlDocument;
                if (doc != null)
                    return doc;
            }
            return null;
        }
        public static IEnumerable<XmlNode> AncestorsAndSelf(this XmlNode node)
        {
            for (; node != null; node = node.ParentNode)
                yield return node;
        }
        public static IEnumerable<XmlNode> DescendantsAndSelf(this XmlNode root)
        {
            if (root == null)
                yield break;
            yield return root;
            foreach (var child in root.ChildNodes.Cast<XmlNode>())
                foreach (var subChild in child.DescendantsAndSelf())
                    yield return subChild;
        }
        public static void UncommentXmlNodes(IEnumerable<XmlComment> comments)
        {
            foreach (var comment in comments.ToList())
                UncommentXmlNode(comment);
        }
        public static void UncommentXmlNode(XmlComment comment)
        {
            if (comment == null)
                throw new NullReferenceException();
            var doc = comment.Document();
            if (doc == null)
                throw new InvalidOperationException();
            var parent = comment.ParentNode;
            var innerText = comment.InnerText;
            XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
            //Set the contents of the document fragment.
            docFrag.InnerXml = innerText;
            XmlNode insertAfter = comment;
            foreach (var child in docFrag.ChildNodes.OfType<XmlElement>().ToList())
            {
                insertAfter = parent.InsertAfter(child, insertAfter);
            }
            parent.RemoveChild(comment);
        }
    }
