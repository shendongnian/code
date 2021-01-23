    [DelimitedRecord(",")]
    class MyClass
    {
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string Title;
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string FullName;
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string Address1;
        /// ... etc        
    }
