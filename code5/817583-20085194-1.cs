    /// <summary>Non-generic interface.</summary>
    public interface IAddingStrategy
    {
        void Add( IAddArgs obj );
        // "context" can be a type that provides additional info
        IAddArgs CreateAddArgs( object context );
    }
    public class NormalAdd : IAddingStrategy<NormalAddArgs>
    {
        public void Add( NormalAddArgs obj ) { }
        public void Add( IAddArgs obj )
        {
            Add( (NormalAddArgs)obj );
        }
        public IAddArgs CreateAddArgs( object context )
        {
            return new NormalAddArgs();
        }
    }
