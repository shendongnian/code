    public class Indicadores
    {
        [Key]
        public Int32 Nro_Serie { get; set; }
        [MaxLength(31)]
        public string Nombre { get; set; }
        public List<Campos> campo { get; set; }
    }
    public class Codigos
    {
        [Key]
        [Column(Order = 0)]
        [DataType("nvarchar")]
        [MaxLength(31)]
        public string Codigo { get; set; }
        [MaxLength(31)]
        public string Descripcion1 { get; set; }
        [MaxLength(31)]
        public string Descripcion2 { get; set; }
        public int CantidadPesadas { get; set; }
        public int PesoTotal { get; set; }
        [Key,ForeignKey("Campos"),Column(Order = 1)]
        public Int16 Nro_Campo { get; set; }
        [ForeignKey("Campos"), Column(Order = 2)]
        public Int32 Nro_Serie { get; set; }
        public Campos Campos { get; set; }
    }
    public class Campos
    {
        [Key, Column(Order = 1)]
        [DataType("smallint")]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Int16 Nro_Campo { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Codigos> codigo { get; set; }
        [Key, Column(Order = 2)]
        public Int32 Nro_Serie { get; set; }
    
        [ForeignKey("Nro_Serie")]
        public Indicadores Indicadores { get; set; }
    } 
