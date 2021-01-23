    void Main()
    {
        var fd = new CsvFileDescription();
        fd.FirstLineHasColumnNames = false;
        fd.QuoteAllFields = false;
        fd.EnforceCsvColumnAttribute = true;
        fd.SeparatorChar = ',';
    
        var txtFileName = @"C:\temp\linqtocsv.csv";
        var data = new[] { new Data { TimeStamp = null, Foo = null, Bar = "" } };
        var cc = new CsvContext();
        cc.Write(data, txtFileName, fd);
    }
    
    class Data
    {
        [CsvColumn(FieldIndex = 0, CanBeNull = true)]
        public string TimeStamp { get; set; }
        [CsvColumn(FieldIndex = 1, CanBeNull = true)]
        public string Foo { get; set; }
        [CsvColumn(FieldIndex = 2, CanBeNull = true)]
        public string Bar { get; set; }
    }
