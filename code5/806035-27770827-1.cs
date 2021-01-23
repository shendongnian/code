	public string ExtractedTypesFlat { get; set; } //for use by the Azure client libs only
	[IgnoreProperty] public List<ExtractedType> ExtractedTypes 
	{
		get 
        { 
            return ExtractedTypesFlat
                         .Split(',')
                         .Select(s => (ExtractedType)Enum.Parse(typeof(ExtractedType), s))
                         .ToList(); 
        }
		set { ExtractedTypesFlat =  String.Join(",", value); }
	}
