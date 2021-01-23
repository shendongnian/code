    /// <summary> The entity involved in the database operation. </summary>
    public object Entity { get; }
    /// <summary> The id to be used in the database operation. </summary>
    public object Id { get; }
    /// <summary>
    /// Retrieves the state to be used in the update.
    /// </summary>
    public object[] State { get; }
    /// <summary>
    /// The old state of the entity at the time it was last loaded from the
    /// database; can be null in the case of detached entities.
    /// </summary>
    public object[] OldState { get; }
