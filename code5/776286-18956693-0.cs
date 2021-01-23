    [Export(typeof(B))]
    public partial class B : WindowBase
    {
        private GeneralViewModel general;
        public GeneralViewModel General
        {
            get
            {
                return this.general ?? (this.general = new GeneralViewModel ());
            }
        }
    
        [ImportingConstructor]
        public B(GeneralViewModel g)
        {
            this.general = g;
        }
    }
