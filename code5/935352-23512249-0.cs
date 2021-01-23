    interface IQueryBuilder{
      string BuildCreateTableQuery();
    }
    class MySqlQueryBuilder : IQueryBuilder {
    }
    class SqlQueryBuilder : IQueryBuilder {
    }
    class OracleQueryBulder : IQueryBuilder{
    }
