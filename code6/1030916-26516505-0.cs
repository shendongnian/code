    public class SharedModuleObject : ISharedModuleObject
    {
        public SharedModuleObject()
        {
            this.DataLavorativa = DateTime.Now;
            this.DataLavorativaPrecedente = DateTime.Now;
        }
        public DateTime DataLavorativaPrecedente { get; set; }
        public DateTime DataLavorativa { get; set; }
    }
