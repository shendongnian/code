    public static class CanvasService
    {
        public static readonly DependencyProperty ChildrenProperty = DependencyProperty.RegisterAttached("Children", typeof(IEnumerable<UIElement>), typeof(CanvasService), new UIPropertyMetadata(childrenChanged));
        private static Dictionary<INotifyCollectionChanged, Canvas> references = new Dictionary<INotifyCollectionChanged, Canvas>();
        public static IEnumerable<UIElement> GetChildren(Canvas cv)
        {
            return cv.GetValue(ChildrenProperty) as IEnumerable<UIElement>;
        }
        public static void SetChildren(Canvas cv, IEnumerable<UIElement> children)
        {
            cv.SetValue(ChildrenProperty, children);
        }
        private static void childrenChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var canvas = target as Canvas;
            repopulateChildren(canvas);
            var be = canvas.GetBindingExpression(ChildrenProperty);
            if (be != null)
            {
                var elements = (be.ResolvedSourcePropertyName == null ? be.ResolvedSource : be.ResolvedSource.GetType().GetProperty(be.ResolvedSourcePropertyName).GetValue(be.ResolvedSource)) as INotifyCollectionChanged;
                if (elements != null)
                {
                    var cv = references.FirstOrDefault(i => i.Value == canvas);
                    if (!cv.Equals(default(KeyValuePair<INotifyCollectionChanged,Canvas>)))
                         references.Remove(cv.Key);
                    references[elements] = canvas;
                    elements.CollectionChanged -= collectionChangedHandler;
                    elements.CollectionChanged += collectionChangedHandler;
                }
            } else references.Clear();            
        }
        private static void collectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            Canvas cv;
            if (references.TryGetValue(sender as INotifyCollectionChanged, out cv))
            {                
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var item in e.NewItems) cv.Children.Add(item as UIElement);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (var item in e.OldItems) cv.Children.Remove(item as UIElement);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        repopulateChildren(cv);
                        break;
                }
            }
        }
        private static void repopulateChildren(Canvas cv)
        {
            cv.Children.Clear();
            var elements = GetChildren(cv);
            foreach (UIElement elem in elements){
                cv.Children.Add(elem);
            }
        }
    }
