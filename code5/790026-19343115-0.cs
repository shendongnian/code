    // Summary:
    //     Returns the equivalent non-generic System.Data.Entity.DbSet object.
    //
    // Returns:
    //     The non-generic set object.
    [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
    public static implicit operator DbSet(DbSet<TEntity> entry);
