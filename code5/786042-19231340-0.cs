    /// <summary>
    /// Update count delegate handler
    /// </summary>
    /// <param name="sender">Obect sender</param>
    /// <param name="ca">Event arguments</param>
    public delegate void UpdateCountHandler(object sender, TaskArgs ca);
    /// <summary>
    /// Update count event
    /// </summary>
    public event UpdateCountHandler UpdateCount;
