    public class Prototype
    {
        [Test, RequiresSTA]
        public void HackReflectionGetParent()
        {
            var lw = new ListView();
            var view = new GridView();
            var gvc = new GridViewColumn();
            view.Columns.Add(gvc);
            lw.View = view;
            var resolvedLw = gvc.GetParents().OfType<ListView>().FirstOrDefault();
            Assert.AreEqual(lw, resolvedLw);
        }
    }
    public static class DependencyObjectExtensions
    {
        private static readonly PropertyInfo InheritanceContextProp = typeof (DependencyObject).GetProperty("InheritanceContext", BindingFlags.NonPublic | BindingFlags.Instance);
        public static IEnumerable<DependencyObject> GetParents(this DependencyObject child)
        {
            while (child != null)
            {
                var parent = LogicalTreeHelper.GetParent(child);
                if (parent == null)
                {
                    if (child is FrameworkElement)
                    {
                        parent = VisualTreeHelper.GetParent(child);
                    }
                    if (parent == null && child is ContentElement)
                    {
                        parent = ContentOperations.GetParent((ContentElement) child);
                    }
                    if (parent == null)
                    {
                        parent = InheritanceContextProp.GetValue(child, null) as DependencyObject;
                    }
                }
                child = parent;
                yield return parent;
            }
        }
    }
