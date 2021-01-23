    public class Person : DependencyObject
    {
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Person));
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
    }
    class ComboAndTextToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values,
            Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string comboBoxText = values[1] as string;
            string textBoxText = values[2] as string;
            if (values[0] is bool && comboBoxText != null && textBoxText != null)
            {
                bool otherItemIsSelected = (bool)values[0];
                return otherItemIsSelected ? textBoxText : comboBoxText;
            }
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value,
            Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _SetMultibinding((Person)spTest.DataContext, Person.NameProperty,
                Tuple.Create((DependencyObject)otherItem, ComboBoxItem.IsSelectedProperty),
                Tuple.Create((DependencyObject)cmbTest, ComboBox.SelectedValueProperty),
                Tuple.Create((DependencyObject)txtTest, TextBox.TextProperty));
        }
        private void _SetMultibinding(DependencyObject target,
            DependencyProperty property,
            params Tuple<DependencyObject, DependencyProperty>[] properties)
        {
            MultiBinding multiBinding = new MultiBinding();
            multiBinding.Converter =
                (IMultiValueConverter)Resources["comboAndTextToTextConverter1"];
            foreach (var sourceProperty in properties)
            {
                Binding bindingT = new Binding();
                bindingT.Source = sourceProperty.Item1;
                bindingT.Path = new PropertyPath(sourceProperty.Item2);
                multiBinding.Bindings.Add(bindingT);
            }
            BindingOperations.SetBinding(target, property, multiBinding);
        }
    }
