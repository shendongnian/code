    public IList<T> ConsultaHql<T>(string sqlQuery)
    {
        ISession session = GetSession();
        IQuery query = session.CreateQuery(sqlQuery);
        return query
           .SetResultTransformer(Transformers.AliasToBean<T>()) // e.g. T is ReceitaGeral
           .List<T>();
    }
