    public class MyExtExtension : MarkupExtension
    {
        public string Output
        {
            get; set;
        }
        public MyExtExtension(string output)
        {
            this.Output = output;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Output;
        }
    }
    public class MarkupExtensionChooser : MarkupExtension
    {
        public string Key
        {
            get;
            set;
        }
        public StringList Param
        {
            get; set;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Key.Equals("ext"))
            {
                return new MyExtExtension(this.Param.Data[0]).ProvideValue(serviceProvider);
            }
            if (this.Key.Equals("ext123"))
            {
                // Custom Logic
            }
            if (this.Key.Equals("ext123123123"))
            {
                // Custom Logic
            }
            if (this.Key.Equals("ext123123123"))
            {
                // Custom Logic
            }
            if (this.Key.Equals("ext12121412423"))
            {
                // Custom Logic
            }
            return this;
        }
    }
    public class StringListTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string val = (string)value;
                return new StringList(val.Split(','));
            }
            return null;
        }
    }
    [TypeConverter(typeof(StringListTypeConverter))]
    public class StringList
    {
        public string[] Data
        {
            get; set;
        }
        public StringList(string[] data)
        {
            this.Data = data;
        }
    }
