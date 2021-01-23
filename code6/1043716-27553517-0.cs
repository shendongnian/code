    public interface IDbContextLocator : IDisposable
    {
        DbContext Current { get; } // Gets the current DbContext instance
        MergeOption DefaultMergeOption { get; set; } // default merge option for new instance of DbContext
        void Reset(); // Throws away the current DbContext instance and creates a new one
    }
