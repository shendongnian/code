    void Main()
    {
    	using( var stream = new MemoryStream() )
    	using( var writer = new StreamWriter( stream ) )
    	using( var reader = new StreamReader( stream ) )
    	using( var csv = new CsvReader( reader ) )
    	{
    		writer.WriteLine( "Header1,Header2,Header3" );
    		writer.WriteLine( "1,2,3" );
    		writer.WriteLine( "5,,6" );
    		writer.WriteLine( "4,4,4" );
    		writer.Flush();
    		stream.Position = 0;
    		
    		csv.Configuration.RegisterClassMap<TestMap>();
    		csv.Configuration.IgnoreReadingExceptions = true;
    		csv.Configuration.SkipEmptyRecords = false;
    		var records = csv.GetRecords<TestData>().ToList();
    		records.Dump();
    	}
    	
    }
    
    public class TestData
    {
        public double? Header1 { get; set; }
        public double? Header2 { get; set; }
        public double? Header3 { get; set; }
    }
    
    public class TestMap : CsvClassMap<TestData>
    {
        public override void CreateMap()
        {
            Map(m => m.Header1).Name("Header1");
            Map(m => m.Header2).Name("Header2");
            Map(m => m.Header3).Name("Header3");
        }
    }
