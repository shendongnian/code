    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class ConverterDispenser:MarkupExtension
    {
        public IValueConverter MainConverter
        {
            get { return new TestConverter();}
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //with the help of serviceProvider you can get information about the surrounding elements and maybe decide depending on those information which converter to return.
            return MainConverter;
        }
    }
