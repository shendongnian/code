    public class MyDialect : MsSql2008Dialect
    {
        public MyDialect()
        {
            RegisterFunction("ConvertDate", 
                   new SQLFunctionTemplate(NHibernateUtil.Class, 
                                            "convert(datetime, ?1, 103)"));
        }
    }
