    public class Contacto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public short ProveedorID { get; set; }
        public Proveedor Proveedor { get; set; }
        public short UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
