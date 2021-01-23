    public partial class EnumComboBox
    {
        public EnumComboBox()
        {
            InitializeComponent();
        }
        public Type EnumType
        {
            get { return (Type)GetValue(EnumTypeProperty); }
            set { SetValue(EnumTypeProperty, value); }
        }
        public Enum SelectedEnumValue
        {
            get { return (Enum)GetValue(SelectedEnumValueProperty); }
            set { SetValue(SelectedEnumValueProperty, value); }
        }
        public static readonly DependencyProperty EnumTypeProperty =
            DependencyProperty.Register("EnumType", typeof(Type), typeof(EnumComboBox), new UIPropertyMetadata(null));
        public static readonly DependencyProperty SelectedEnumValueProperty =
            DependencyProperty.Register("SelectedEnumValue", typeof(Enum), typeof(EnumComboBox), new UIPropertyMetadata(null));
        private readonly Dictionary<string, Enum> _conversionDictionary = new Dictionary<string, Enum>();
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == EnumTypeProperty)
            {
                foreach (var en in Enum.GetValues(EnumType))
                {
                    var descr = Description((Enum)en);
                    _conversionDictionary.Add(descr, (Enum)en);
                }
                ItemsSource = _conversionDictionary.Keys.OrderBy(x => x);
            }
            else if (e.Property == SelectedItemProperty)
            {
                SelectedEnumValue = _conversionDictionary[e.NewValue.ToString()];
            }
            else if (e.Property == SelectedEnumValueProperty)
            {
                SetValue(SelectedItemProperty, Description((Enum)e.NewValue));
            }
            base.OnPropertyChanged(e);
        }
        public static string Description(Enum value)
        {
            if (value == null)
                return null;
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            if (field == null)
                return null;
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), true)
                        .Cast<DescriptionAttribute>()
                        .FirstOrDefault();
            return attr == null ? value.ToString() : attr.Description;
        }
    }
