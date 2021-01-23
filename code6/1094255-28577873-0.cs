    public enum Bezel 
    (
        Flashing(0),
        SolidOn(1),
        None(254);
    
        public final int value;
        public Bezel( int value )
        {
            this.value = value;
        }
    )
