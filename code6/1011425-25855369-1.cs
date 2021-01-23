    public static class FlowDocumentHelper
    {
        public static IEnumerable<DependencyObject> WalkTreeDown(this DependencyObject root)
        {
            if (root == null)
                throw new ArgumentNullException();
            yield return root;
            foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
                foreach (var descendent in child.WalkTreeDown())
                    yield return descendent;
        }
        public static IEnumerable<DependencyObject> WalkTreeUp(this DependencyObject child)
        {
            for (; child != null; child = LogicalTreeHelper.GetParent(child))
                yield return child;
        }
        public static void RemoveHyperlinks(this FlowDocument doc)
        {
            var allLinks = doc.WalkTreeDown().OfType<Hyperlink>().ToArray();
            for (int iLink = allLinks.Length - 1; iLink >= 0; iLink--)
            {
                var link = allLinks[iLink];
                var range = new TextRange(link.ContentStart.GetInsertionPosition(LogicalDirection.Backward), link.ContentEnd.GetInsertionPosition(LogicalDirection.Forward));
                var first = link.Inlines.FirstInline;
                var last = link.Inlines.LastInline;
                link.Inlines.Add(new Run(" "));
                link.Inlines.InsertBefore(first, new Run(" "));
                var childRange = new TextRange(first.ContentStart, last.ContentEnd);
                using (MemoryStream ms = new MemoryStream())
                {
                    string format = DataFormats.XamlPackage;
                    childRange.Save(ms, format, true);
                    ms.Seek(0, SeekOrigin.Begin);
                    range.Text = string.Empty;
                    range.Load(ms, format);
                }
            }
        }
    }
