    public class Almacen
    {
        [Key, Column( Order = 0 )]
        public string co_alma { get; set; }
        public string des_alm { get; set; }
        [Required, ForeignKey( "Articulo" ), Column( Order = 1 )]
        public string co_art { get; set; }
        public double stock_act { get; set; }
        public Articulo Articulo { get; set; }
    }
