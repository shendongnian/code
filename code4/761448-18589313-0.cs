    [FieldQuoted()] // Quoted with "
    public string CustomerName
    
    [FieldQuoted('[')] // Quoted between [brackets]
    public string CustomerName
    
    [FieldQuoted('"', QuoteMode.OptionalForBoth)] // Optional quoted when read or write
    public string CustomerName
    
    [FieldQuoted('"', MultilineMode.AllowForBoth)] // Indicates that the quoted string can span multiple lines
    public string CustomerName
