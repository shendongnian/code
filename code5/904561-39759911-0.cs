public string Get&lt;TEntity, TId&gt;(TId id)
    where TEntity: IHasAnIdField&lt;TId&gt;, IEquatable&lt;TId&gt;
{
    var query = new SQLinq&lt;TEntity&gt;();
    // The following statement does not compile due to error in lambda with "==" operator
    // "Operator '==' cannot be applied to operands of type 'TId' and 'TId'"
    query = query.Where((Expression<Func<TEntity, bool>>)(i => i.Id == id));
    var sql = query.ToSQL().ToQuery();
    return sql;
}
