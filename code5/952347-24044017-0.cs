    /// <summary>
    /// Conditionally return the true or false part, dependention on the criterion
    /// </summary>
    /// <param name="criterion">The criterion.</param><param name="whenTrue">The when true.
    ///    </param><param name="whenFalse">The when false.</param>
    /// <returns/>
    public static IProjection Conditional(ICriterion criterion
                                        , IProjection whenTrue
                                        , IProjection whenFalse);
