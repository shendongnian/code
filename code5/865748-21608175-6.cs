    public class ArrayToListConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return new List<string>();
            return ((string[]) value).ToList();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
             throw new NotImplementedException();
        }
    }
------------------------------------------------------------------
     public partial class Xyz : UserControl
     {
        public static readonly DependencyProperty LsProperty =
                DependencyProperty.Register("Ls", typeof(List<string>), typeof(Xyz),
                      new FrameworkPropertyMetadata(null));
      
        public List<string> Ls
        {
            get { return (List<string>)GetValue(Xyz.LsProperty); }
            set { SetValue(Xyz.LsProperty, value); }
        }
        public Xyz()
        {
            InitializeComponent();
        }
      }
