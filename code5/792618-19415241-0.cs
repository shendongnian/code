    public class DAL_Base<T> where T : IDisposable, new() {
    
      private string connStr;
    
      public DAL_Base() {
        connStr = ConfigurationManager.ConnectionStrings["CompanyDatabaseConnStr"].ConnectionString;
      }
        private Func<IDataRecord, T> _fillFunc;
        
        public DAL_Base(Func<IDataRecord, T> fillFunc) : this() {
                _fillFunc = fillFunc;
        }
        
            // ... 
        internal TList<T> Get() {
        if (String.IsNullOrEmpty(SP_GET)) {
          throw new NotSupportedException(string.Format("Get Procedure does not exist for {0}.", typeof(T)));
        }
        var list = new TList<T>();
        using (var cmd = new SqlCommand(SP_GET, m_openConn)) {
          cmd.CommandType = cmd.GetCommandTextType();
          using (var r = cmd.ExecuteReader()) {
            while (r.Read()) {
              list.Add(_fullFunc(r));
    }
