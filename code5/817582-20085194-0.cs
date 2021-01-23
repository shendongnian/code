    /// <summary>Some common base type.</summary>
    public interface IAddArgs {}
    /// <summary>Non-generic interface.</summary>
    public interface IAddingStrategy
    {
        void Add( IAddArgs obj );
    }
    /// <summary>Generic version.</summary>
    /// <typeparam name="T"></typeparam>
    public interface IAddingStrategy<T> : IAddingStrategy
        where T : IAddArgs
    {
        void Add( T obj );
    }
    public class NormalAddArgs : IAddArgs {}
    public class NormalAdd : IAddingStrategy<NormalAddArgs>
    {
        public void Add( NormalAddArgs obj )
        {
        }
        public void Add( IAddArgs obj )
        {
            Add( (NormalAddArgs)obj );
        }
    }
