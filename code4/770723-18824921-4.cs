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
            get
			{
				if (Validation.GetHasError(this))
					return string.Join(Environment.NewLine, Validation.GetErrors(this).Select(e => e.ErrorContent));
				return null;
			}
        }
        public string this[string columnName]
        {
            get
            {
                // use a specific validation or ask for UserControl Validation Error 
                if (Validation.GetHasError(this))
				{
					var error = Validation.GetErrors(this).FirstOrDefault(e => ((BindingExpression)e.BindingInError).TargetProperty.Name == columnName);
					if (error != null)
						return error.ErrorContent as string;
				}
				return null;
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
