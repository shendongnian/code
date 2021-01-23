    [Key,ForeignKey("Campos"),Column(Order = 1)]
    public Int16 Nro_Campo { get; set; }
    [ForeignKey("Campos"), Column(Order = 2)]
    public Int32 Nro_Serie { get; set; }
    public Campos Campos { get; set; }
