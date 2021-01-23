    [Key,Column(Order = 1)]
    public Int16 Nro_Campo { get; set; }
    [Column(Order = 2)]
    public Int32 Nro_Serie { get; set; }
    [ForeignKey("Nro_compo, Nro_Serie")]
    public Campos Campos { get; set; }
