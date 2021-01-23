    public class Shared
    {
        public Shared( Shared source )
        {
            this.String1 = source.String1;
        }
    }
    
    public class ImplementedOne : Shared
    {
        public ImplementedOne( Shared source ) : base( source )
        {
        }
    }
