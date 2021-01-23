     public Foo()
     {
        public Foo()
        {
            _bars = new InterfaceCollectionAdapter<Bar, IBar>(() => this.Bars, (value) => { this.Bars = value; });
        }
        private InterfaceCollectionAdapter<Bar, IBar> _bars;
        [NotMapped]
        ICollection<IBar> IFoo.Bars
        {
            get
            {
                return _bars;
            }
        }
