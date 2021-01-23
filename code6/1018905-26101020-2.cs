    /// <param name="path">Lambda expression returning association path</param>
    /// <param name="alias">Lambda expression returning alias reference</param>
    /// <param name="joinType">Type of join</param>
    /// <param name="withClause">Additional criterion for the SQL on clause</param>
    /// <returns>
    /// criteria instance
    /// </returns>
    IQueryOver<TRoot, TSubType> JoinAlias<U>(Expression<Func<U>> path
         , Expression<Func<U>> alias, JoinType joinType
         , ICriterion withClause);
