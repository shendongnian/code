    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    #region Model
    public class TestData : INotifyPropertyChanged
    {
        private bool _hasError = false;
        public bool HasError
        {
            get
            {
                return _hasError;
            }
            set
            {
                _hasError = value;
                NotifyPropertyChanged("HasError");
            }
        }
        private string _testText = "0";
        public string TestText
        {
            get
            {
                return _testText;
            }
            set
            {
                _testText = value;
                NotifyPropertyChanged("TestText");
            }
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string sProp)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(sProp));
            }
        }
        #endregion
    }
    #endregion
    #region ValidationRule
    public class OnlyNumbersValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = new ValidationResult(true, null);
            string NumberPattern = @"^[0-9-]+$";
            Regex rgx = new Regex(NumberPattern);
            if (rgx.IsMatch(value.ToString()) == false)
            {
                result = new ValidationResult(false, "Must be only numbers");
            }
            return result;
        }
    }
    #endregion
    public class ProtocolSettingsLayout
    {       
        public static readonly DependencyProperty MVVMHasErrorProperty= DependencyProperty.RegisterAttached("MVVMHasError", 
                                                                        typeof(bool),
                                                                        typeof(ProtocolSettingsLayout),
                                                                        new FrameworkPropertyMetadata(false, 
                                                                                                      FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                      null,
                                                                                                      CoerceMVVMHasError));
        public static bool GetMVVMHasError(DependencyObject d)
        {
            return (bool)d.GetValue(MVVMHasErrorProperty);
        }
        public static void SetMVVMHasError(DependencyObject d, bool value)
        {
            d.SetValue(MVVMHasErrorProperty, value);
        }
        private static object CoerceMVVMHasError(DependencyObject d,Object baseValue)
        {
            bool ret = (bool)baseValue;
            if (BindingOperations.IsDataBound(d,MVVMHasErrorProperty))
            {
                if (GetHasErrorDescriptor(d)==null)
                {
                    DependencyPropertyDescriptor desc = DependencyPropertyDescriptor.FromProperty(Validation.HasErrorProperty, d.GetType());
                    desc.AddValueChanged(d,OnHasErrorChanged);
                    SetHasErrorDescriptor(d, desc);
                    ret = System.Windows.Controls.Validation.GetHasError(d);
                }
            }
            else
            {
                if (GetHasErrorDescriptor(d)!=null)
                {
                    DependencyPropertyDescriptor desc= GetHasErrorDescriptor(d);
                    desc.RemoveValueChanged(d, OnHasErrorChanged);
                    SetHasErrorDescriptor(d, null);
                }
            }
            return ret;
        }
        private static readonly DependencyProperty HasErrorDescriptorProperty = DependencyProperty.RegisterAttached("HasErrorDescriptor", 
                                                                                typeof(DependencyPropertyDescriptor),
                                                                                typeof(ProtocolSettingsLayout));
        private static DependencyPropertyDescriptor GetHasErrorDescriptor(DependencyObject d)
        {
            var ret = d.GetValue(HasErrorDescriptorProperty);
            return ret as DependencyPropertyDescriptor;
        }
        private static void OnHasErrorChanged(object sender, EventArgs e)
        {
            DependencyObject d = sender as DependencyObject;
            if (d != null)
            {
                d.SetValue(MVVMHasErrorProperty, d.GetValue(Validation.HasErrorProperty));
            }
        }
       private static void SetHasErrorDescriptor(DependencyObject d, DependencyPropertyDescriptor value)
       {
            var ret = d.GetValue(HasErrorDescriptorProperty);
            d.SetValue(HasErrorDescriptorProperty, value);
        }
    }
