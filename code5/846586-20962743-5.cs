    public partial class ReadOnlyCollectionEditor : UserControl, ITypeEditor
    {
        public ReadOnlyCollectionEditor()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof (IList<string>), typeof (ReadOnlyCollectionEditor), new PropertyMetadata(default(IList<string>)));
        public IList<string> Value
        {
            get { return (IList<string>)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem)
        {
            var binding = new Binding("Value")
            {
                Source = propertyItem,
                Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay
            };
            BindingOperations.SetBinding(this, ValueProperty, binding);
            return this;
        }
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            ReadOnlyCollectionViewer viewer = new ReadOnlyCollectionViewer {DataContext = this};
            viewer.ShowDialog();
        }
    }
