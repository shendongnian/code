        public class MyDbCommandInterceptor : IDbCommandInterceptor 
        {
          public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
          {
            if (command.CommandText.Contains("__MARKER__"))
            {
              // Do some funky text replacement
            }
          }
          ...
        }
        public partial class MyEntity 
        {
          [Column("__MARKER__COLUMNAME"]
          public string Coord { get; set; }
        }
        // Before you run the query:
        MyDbCommandInterceptor interceptor = new MyDbCommandInterceptor();
        DBInterception.Add(interceptor);
