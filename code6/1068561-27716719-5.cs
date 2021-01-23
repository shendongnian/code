    public static class FlowDocumentExtensions
    {
        public static IEnumerable<Paragraph> Paragraphs(this FlowDocument doc)
        {
            return doc.Descendants().OfType<Paragraph>();
        }
    }
    public static class DependencyObjectExtensions
    {
        public static IEnumerable<DependencyObject> Descendants(this DependencyObject root)
        {
            if (root == null)
                yield break;
            yield return root;
            foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
                foreach (var descendent in child.Descendants())
                    yield return descendent;
        }
    }
