    [IgnoreFirst(1)] 
    [DelimitedRecord(",")]
    class DailyValues
    {
    	[FieldConverter(ConverterKind.Date, "yyyy-MM-dd")] 
        public DateTime Date;
        public decimal Open;
        public decimal High;
        public decimal Low;
        public decimal Close;
        public decimal Volume;
        public decimal AdjClose;
    	[FieldNotInFile] 
    	public decimal SomethingCalculated;
    }
