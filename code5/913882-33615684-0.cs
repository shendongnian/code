    public class CustomLanguageBindingParser : MvxBindingParser , IMvxLanguageBindingParser
    {
        protected override MvxSerializableBindingDescription ParseBindingDescription()
        {
            this.SkipWhitespace();
            string resourceName = (string)this.ReadValue();
            // Pass the resource name in as the parameter on the StringResourceConverter.
            return new MvxSerializableBindingDescription
            {
                Converter = "StringResource",
                ConverterParameter = resourceName,
                Path = null,
                Mode = MvxBindingMode.OneTime
            };
        }
        public string DefaultConverterName { get; set; }
        public string DefaultTextSourceName { get; set; }
    }
