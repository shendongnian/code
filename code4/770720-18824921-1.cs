    public partial class LabelTextBox : UserControl, IDataErrorInfo
    {       
        public LabelTextBox()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TextBoxTextProperty =
            DependencyProperty.Register(
                "TextBoxText",
                typeof(string),
                typeof(LabelTextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );
        #region IDataErrorInfo Members
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {
                // use a specific validation or ask for UserControl Validation Error 
                return Validation.GetHasError(this) ? Validation.GetErrors(this)[0].ErrorContent.ToString() : null;
            }
        }
        #endregion
        [Browsable(true)]
        public string LabelText
        {
            get { return BaseLabel.Content.ToString(); }
            set { BaseLabel.Content = value; }
        }
        [Browsable(true)]
        public string TextBoxText
        {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { 
                SetValue(TextBoxTextProperty, value);
            }
        }
        [Browsable(true)]
        public double TextBoxWidth
        {
            get { return BaseTextBox.Width; }
            set { BaseTextBox.Width = value; }
        }
    }
