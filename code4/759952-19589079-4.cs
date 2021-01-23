     public class LeafDataTemplateSelector :  DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null)
            {
                if (item is InstallationManifesFile)
                    return
                            element.FindResource("FileKey")
                            as DataTemplate;
                else if (item is InstallationManifestHook)
                    return element.FindResource("HookKey")
                            as DataTemplate;
            }
            return null;
        }
    }
    public class CompositeCollectionConverter : IMultiValueConverter
    {
        public object Convert(object[] values
            , Type targetType
            , object parameter
            , System.Globalization.CultureInfo culture)
        {
            var res = new CompositeCollection();
            foreach (var item in values)
                if (item is IEnumerable && item != null)
                    res.Add(new CollectionContainer()
                    {
                        Collection = item as IEnumerable
                    });
            return res;
        }
        public object[] ConvertBack(object value
            , Type[] targetTypes
            , object parameter
            , System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
