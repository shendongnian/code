    public class OracleDataContextAdapter : IDbMethodCaller
    {
    
    
        private OracleDataContext dataContext;
    
        public OracleDataContextAdapter(OracleDataContext oracleContext)
        {
    
           this.dataContext =  oracleContext;  
        }
    
        public new IEnumerable<object> ExecuteMethodCall(string methodName, IEnumerable<string> parameters)
        {
            Debug.WriteLine("OracleDataContextAdapter.ExecuteMethodCall");
    
            return this.dataContext.ExecuteMethodCall(methodName, parameters);
        }
    }
