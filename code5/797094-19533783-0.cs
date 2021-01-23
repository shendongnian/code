    public class AttachedPropertyClass 
    {
        private static readonly {PropertyType} DefaultValue = ...;
        public static readonly DependencyProperty {PropertyName}Property
           = DependencyProperty.RegisterAttached("{PropertyName}",
        typeof({PropertyType}), typeof({AttachedType}),
        new FrameworkPropertyMetadata(DefaultValue, PostionPropertyChanged));;
        public static void Set{PropertyName}(DependencyObject d, {PropertyType} value)
        {
            d.SetValue({PropertyName}, value);
        }
        public static {PropertyType} Get{PropertyName}(DependencyObject DepObject)
        {
            return ({PropertyType})DepObject.GetValue({PropertyName});
        }
        private static void ChangeHandler(DependencyObject obj, DependencyPropertyChangedEventArgs e);
    }
