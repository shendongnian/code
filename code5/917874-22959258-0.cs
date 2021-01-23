        public class ArtModels
        {
            [Key]
            public int idArt { get; set; }
            [Required(ErrorMessage = "Codigo del Articulo es Requerido")]
            public string co_art { get; set; }
            [Required]
            public string des_art { get; set; }
            [Required]
            public string modelo { get; set; }
            [Required]
            public string referencia { get; set; }
            [ForeignKey("Linea")]
            public int IdLinea { get; set; }
            public virtual LineaModels Linea { get; set; }
        }
        public class LineaModels
        {
            [Key]
            public int IdLinea { get; set; }
            [Required(ErrorMessage = "Indique el Codigo")]
            public string co_lin { get; set; }
            [Required(ErrorMessage = "Indique la Descripción")]
            public string des_lin { get; set; }
        }
        public class AppContext : DbContext
        {
            public DbSet<ArtModels> ArtModelses { get; set; }
            public DbSet<LineaModels> LineaModelses { get; set; }
        }
