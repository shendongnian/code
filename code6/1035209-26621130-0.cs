    public enum ObjectState
    {
    
        /// <summary>
        /// Entity wasn't changed.
        /// </summary>
    
        Unchanged,
    
        /// <summary>
        /// Entity is new and needs to be added.
        /// </summary>
        Added,
    
        /// <summary>
        /// Entity has been modified.
        /// </summary>
        Modified,
    
        /// <summary>
        /// Entity has been deleted (physical delete).
        /// </summary>
        Deleted
    }
