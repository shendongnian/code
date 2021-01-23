    public static class RichTextBoxExtensions
    {
        public static IEnumerable<Paragraph> Paragraphs(this RichTextBox richTextBox)
        {
            if (richTextBox == null)
                throw new ArgumentNullException();
            if (richTextBox.Document == null)
                return Enumerable.Empty<Paragraph>();
            return richTextBox.Document.Descendants().OfType<Paragraph>();
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
        public static IEnumerable<DependencyObject> Ancestors(this DependencyObject child)
        {
            if (child == null)
                yield break;
            for (; child != null; child = LogicalTreeHelper.GetParent(child))
                yield return child;
        }
    }
