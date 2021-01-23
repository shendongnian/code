    public sealed partial class DateTimeControl : UserControl
    {
        public String ControlType
        {
            get { return (String)GetValue(ControlTypeProperty); }
            set { SetValue(ControlTypeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ControlType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlTypeProperty =
            DependencyProperty.Register("ControlType", typeof(String), typeof(DateTimeControl), new PropertyMetadata(""));
        
        public DateTime TheDate
        {
            get { return (DateTime)GetValue(TheDateProperty); }
            set { SetValue(TheDateProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TheDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheDateProperty =
            DependencyProperty.Register("TheDate", typeof(DateTime), typeof(DateTimeControl), new PropertyMetadata(DateTime.Now));        
        public DateTimeControl()
        {
            this.InitializeComponent();
        }
        public DateTimeControl(String ControlTypeIn)
        {
            this.InitializeComponent();
            ControlType = ControlTypeIn; 
            switch (ControlType.ToUpper())
            {
                case "DATE_TIME":
                    this.theDatePicker.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    this.theTimePicker.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    break;
                case "DATE":
                    this.theDatePicker.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    this.theTimePicker.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    break;
                case "TIME":
                    this.theDatePicker.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    this.theTimePicker.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    break;
                default:
                    break;
            }
            DateTimeToDateTimeOffsetConverter converter = new DateTimeToDateTimeOffsetConverter();
            Binding bdDate = new Binding();
            bdDate.Mode = BindingMode.TwoWay;
            bdDate.Converter = converter;
            bdDate.Path = new PropertyPath("TheDate");
            bdDate.Source = this;
            Binding bdTime = new Binding();
            bdTime.Mode = BindingMode.TwoWay;
            bdTime.Converter = converter;
            bdTime.ConverterParameter = TheDate;
            bdTime.Path = new PropertyPath("TheDate");
            bdTime.Source = this;
            if (ControlType.ToUpper() == "DATE_TIME")
            {
                theDatePicker.SetBinding(DatePicker.DateProperty, bdDate);
                theTimePicker.SetBinding(TimePicker.TimeProperty, bdTime);
            }
            else if (ControlType.ToUpper() == "DATE")
            {
                theDatePicker.SetBinding(DatePicker.DateProperty, bdDate);
            }
            else if (ControlType.ToUpper() == "TIME")
            {
                theTimePicker.SetBinding(TimePicker.TimeProperty, bdTime);
            }
        }
    }
    public class DateTimeToDateTimeOffsetConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (targetType == typeof(TimeSpan))
                {
                    if (parameter != null)
                    {
                        DateTime dt = (DateTime)value;
                        //Get the timespan from subtracting the date from the original DateTime
                        //this returns a timespan representing the time component of the DateTime
                        TimeSpan ts = dt - dt.Date;
                        return ts;
                    }
                    else
                    {
                        return new DateTimeOffset(DateTime.Now);
                    }
                }
                DateTime date = (DateTime)value;
                return new DateTimeOffset(date);
            }
            catch (Exception ex)
            {
                return DateTimeOffset.MinValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value.GetType() == typeof(TimeSpan))
                {
                    TimeSpan ts = (TimeSpan)value;
                    DateTime dateParam = (DateTime)parameter;
                    return new DateTime(dateParam.Year,dateParam.Month,dateParam.Day,ts.Hours,ts.Minutes,ts.Seconds);
                }
                DateTimeOffset dto = (DateTimeOffset)value;
                return dto.DateTime;
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
    }
