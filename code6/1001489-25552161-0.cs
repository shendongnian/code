    public class MyEmptyFieldConverter : ConverterBase
    {
        protected override bool CustomNullHandling
        {
            /// you need to tell the converter not 
            /// to handle empty values automatically
            get { return true; } 
        }
        public override object StringToField(string from)
        {
            if (String.IsNullOrWhiteSpace(from))
                return "NULL";
            return from;
        }
    }
