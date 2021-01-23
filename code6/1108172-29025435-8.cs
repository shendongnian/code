    enum FieldDeserializationStatus { WasNotPresent, WasSetToNull, HasValue }
    
    interface IHasFieldStatus
    {
    	Dictionary<string, FieldDeserializationStatus> FieldStatus { get; set; }
    }
    
    class FooDTO : IHasFieldStatus
    {
    	public string Field1 { get; set; }
    	public BarDTO Nested { get; set; }
    	public Dictionary<string, FieldDeserializationStatus> FieldStatus { get; set; }
    }
    
    class BarDTO : IHasFieldStatus
    {
    	public int Num { get; set; }
    	public string Str { get; set; }
    	public bool Bool { get; set; }
    	public decimal Dec { get; set; }
    	public Dictionary<string, FieldDeserializationStatus> FieldStatus { get; set; }
    }
