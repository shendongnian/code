    public static class CollectionViewSourceFilter
    {
        public static IFilterCollectionViewSource GetFilterObject(CollectionViewSource obj)
        {
            return (IFilterCollectionViewSource)obj.GetValue(FilterObjectProperty);
        }
        public static void SetFilterObject(CollectionViewSource obj, IFilterCollectionViewSource value)
        {
            obj.SetValue(FilterObjectProperty, value);
        }
        public static void FilterObjectChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is IFilterCollectionViewSource oldFilterObject
                && sender is CollectionViewSource oldCvs)
            {
                oldCvs.Filter -= oldFilterObject.Filter;
                oldFilterObject.FilterRefresh -= (s, e2) => oldCvs.View.Refresh();
            }
            if (e.NewValue is IFilterCollectionViewSource filterObject
                && sender is CollectionViewSource cvs)
            {
                cvs.Filter += filterObject.Filter;
                filterObject.FilterRefresh += (s,e2) => cvs.View.Refresh();
            }
        }
        public static readonly DependencyProperty FilterObjectProperty = DependencyProperty.RegisterAttached(
            "FilterObject",
            typeof(Interfaces.IFilterCollectionViewSource),
            typeof(CollectionViewSourceFilter),
            new PropertyMetadata(null,FilterObjectChanged)
        );
    }
