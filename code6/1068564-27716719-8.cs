    public static class FlowDocumentExtensions
    {
        public static IEnumerable<Paragraph> Paragraphs(FlowDocument doc)
        {
            return DependencyObjectExtensions.Descendants(doc).OfType<Paragraph>();
        }
    }
    public static class DependencyObjectExtensions
    {
        public static IEnumerable<DependencyObject> Descendants(DependencyObject root)
        {
            if (root == null)
                yield break;
            yield return root;
            foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
                foreach (var descendent in child.Descendants())
                    yield return descendent;
        }
    }
