    class MyDateBinder : INotifyPropertyChanged, IBindableComponent
    {
        public MyDateBinder()
        {
        }
        private string customFormat;
        public string CustomFormat
        {
            get
            {
                return customFormat;
            }
            set
            {
                if (customFormat != value)
                {
                    customFormat = value;
                    if (format == DateTimePickerFormat.Custom)
                    {
                        UpdateText();
                        FirePropertyChanged("Text");
                    }
                }
            }
        }
        private DateTimePickerFormat format = DateTimePickerFormat.Short;
        public DateTimePickerFormat Format
        {
            get
            {
                return format;
            }
            set
            {
                if (format != value)
                {
                    format = value;
                    UpdateText();
                    FirePropertyChanged("Text");
                }
            }
        }
        private string text;
        [Bindable(true)]
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text != value)
                {
                    text = value;
                    FirePropertyChanged("Text");
                    UpdateDate();
                    FirePropertyChanged("Value");
                }
            }
        }
        private DateTime date = DateTime.Now;
        [Bindable(true)]
        public DateTime? Value
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    if (value == null)
                    {
                        date = DateTime.Now;
                    }
                    else
                    {
                        date = Convert.ToDateTime(value);
                    }
                    FirePropertyChanged("Value");
                    UpdateText();
                    FirePropertyChanged("Text");
                }
            }
        }
        private void UpdateText()
        {
            switch (format)
            {
                case DateTimePickerFormat.Time:
                    text = date.TimeOfDay.ToString();
                    break;
                default:
                case DateTimePickerFormat.Short:
                    text = date.ToShortDateString() + " " + date.ToShortTimeString();
                    break;
                case DateTimePickerFormat.Long:
                    text = date.ToLongDateString() + " " + date.ToLongTimeString();
                    break;
                case DateTimePickerFormat.Custom:
                    text = date.ToString(customFormat);
                    break;
            }
        }
        private void UpdateDate()
        {
            if(!DateTime.TryParseExact(text, CustomFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                date = DateTime.Now;
            }
        }
        private BindingContext bindingContext = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Advanced),
         Browsable(false)]
        public BindingContext BindingContext
        {
            get
            {
                if (null == bindingContext)
                {
                    bindingContext = new BindingContext();
                }
                return bindingContext;
            }
            set { bindingContext = value; }
        }
        private ControlBindingsCollection databindings;
        [ParenthesizePropertyName(true),
         RefreshProperties(RefreshProperties.All),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
         Category("Data")]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (null == databindings)
                {
                    databindings = new ControlBindingsCollection(this);
                }
                return databindings;
            }
            set { databindings = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event EventHandler Disposed;
        public ISite Site
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void Dispose()
        {
            if (Disposed != null)
                Disposed(this, new EventArgs());
        }
    }
