    /// <summary>
    /// Gets the logger for the specified activation context, creating it if necessary.
    /// </summary>
    /// <param name="context">The ninject creation context.</param>
    /// <returns>The newly-created logger.</returns>
    public ILogger GetLogger(IContext context)
    {
        return this.GetLogger(context.Request.Target.Member.DeclaringType);
    }
