    public partial class Orden
    {
        public int OrdenId { get; set; }
        public Orden()
        {
            this.Orden_Bitacora = new HashSet<Orden_Bitacora>();
        }    
        //Attributes list    
        public virtual ICollection<Orden_Bitacora> Orden_Bitacora { get; set; }
    }
