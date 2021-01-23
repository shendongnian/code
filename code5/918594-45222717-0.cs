	// This will throw an error. There is no such type name.
	[Column(TypeName = "Invalid")]
	public string Column1 { get; set; }
	// Works.
	[Column(TypeName = "varchar")]
	public string Column1 { get; set; }
