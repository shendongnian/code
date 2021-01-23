    class StockForecastReportExport
    {
        private decimal subtractedValue;
    
        public StockForecastReportExport(decimal subtractedValue)
        {
            this.subtractedValue = subtractedValue; 
        }
    
        [ExcelCol("F")]
        public decimal Col1 { get { return CurrentQuantity - (1 * subtractedValue); } }
    
        [ExcelCol("G")]
        public decimal Col2 { get { return CurrentQuantity - (2 * subtractedValue); } }
    
        [ExcelCol("H")]
        public decimal Col3 { get { return CurrentQuantity - (3 * subtractedValue); } }
    
        public decimal CurrentQuantity { get; set; }
    }
