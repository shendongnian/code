    public string X0 { get; set; } // Auto implemented property
    private string field;
    public string X0 { 
         get { return field * 2; } 
         set { field = value; }
    } // Custom property with backing field
