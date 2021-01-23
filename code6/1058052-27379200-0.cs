    public class IdVolumeNameRow
    {
   	    [CsvColumn(FieldIndex = 1)]
    	public string ID { get; set; }
    	[CsvColumn(FieldIndex = 2)]
    	public decimal Volume { get; set; }
    	[CsvColumn(FieldIndex = 3)]
    	public string Name{ get; set; }
    }
