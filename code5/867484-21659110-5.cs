    public class MyConfiguration : DbConfiguration 
    { 
        public MyConfiguration() 
        { 
            this.SetExecutionStrategy("System.Data.SqlClient", () => SuspendExecutionStrategy 
              ? (IDbExecutionStrategy)new DefaultExecutionStrategy() 
              : new SqlAzureExecutionStrategy()); 
        } 
  
        public static bool SuspendExecutionStrategy 
        { 
            get 
            { 
                return (bool?)CallContext.LogicalGetData("SuspendExecutionStrategy") ?? false; 
            } 
            set 
            { 
                CallContext.LogicalSetData("SuspendExecutionStrategy", value); 
            } 
        } 
    } 
