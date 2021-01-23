    public class CustomPostgresDialect : PostgreSQLDialect
    {
        public CustomPostgresDialect()
        {
            this.RegisterFunction(
                "split_part",
                new SQLFunctionTemplate(
                    NHibernateUtil.String,
                    "split_part(?1, ?2, ?3"));
        }
    }
