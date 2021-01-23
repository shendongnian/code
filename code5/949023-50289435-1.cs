    public class Stackoverflow<T> 
    {
        
        public  delegate T CallingDelegate(string tableName, string fieldName, params IDbDataParameter[] parameters); 
        public static T GetField(string tableName, string fieldName, params IDbDataParameter[] parameters)
        {
            //Code
            return default(T);
        }        
        
    }
    public class MainProgram
    {
        static void Main(string[] args)
        {
            Stackoverflow<int>.CallingDelegate del = Stackoverflow<int>.GetField;
            del("SampleTableName", "SampleField", new[]{
                new SqlParameter{DbType = DbType.Int32,Size = sizeof(Int32),ParameterName = "Id",Direction = ParameterDirection.Input},
                new SqlParameter{DbType = DbType.String,Size = 100,ParameterName = "name",Direction = ParameterDirection.Output}
            });
        }
    
    }
