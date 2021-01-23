    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data;
    namespace PruebasSQL
    {
        class Program
        {
            const string ConnString = @"";
            static void Main(string[] args)
            {
                ClearData("A");
            }
			public static void ClearData(string state)
			{
				const string queryToExec = @"DECLARE @int INT;" +
										   "SELECT @int  =  COUNT(*) " +
										   "FROM [Table] " +
										   "WHERE STATE = @State;" +
										   "DELETE TOP (@int - 1 ) " + //NOTICE THIS LINE
										   "FROM [Table] ";
				List<SqlParameter> param = new List<SqlParameter>()
				{
					new SqlParameter {ParameterName = "@State", SqlDbType = SqlDbType.VarChar, Value = state},
				};
				ExecQuery(queryToExec, param);
			}
			public static void ExecQuery(string query, List<SqlParameter> paramCollection = null)
			{
				using (SqlConnection conn = new SqlConnection(ConnString))
				{
					using (SqlCommand mySqlCom = new SqlCommand())
					{
						mySqlCom.CommandText = query;
						if (paramCollection != null) mySqlCom.Parameters.AddRange(paramCollection.ToArray());
						mySqlCom.Connection = conn;
						conn.Open();
						mySqlCom.ExecuteNonQuery();
					}
				}
			}
		}
	}
