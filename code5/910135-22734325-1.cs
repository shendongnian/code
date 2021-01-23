    public class Articulo
    {
        [Required]
        [Key]
        public string co_art { get; set; }
        public string des_art { get; set; }
        public string modelo { get; set; }
        public string co_lin { get; set; }
        public string co_subl { get; set; }
        public string co_cat { get; set; }
        public string co_col { get; set; }
        [ForeignKey( "co_art" )]
        public ICollection<Almacen> Almacenes { get; set; }
    }
