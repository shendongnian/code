    public class CultureAwareBinding : Binding
    {
        public CultureAwareBinding(string path)
            : base(path)
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }
    }
