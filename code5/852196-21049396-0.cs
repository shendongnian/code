    public class Engine
     {
    	private const string _connectionString = "Data Source=.;Initial Catalog=MY_Table;Integrated Security=True";   
    
    	public Engine() {
    	}
    
    	public DataTable Selecting_DT(string tableName) {
    		using(var conn = new SqlConnection(_connectionString)) {
    			conn.Open();
    			using(var cmd = new SqlCommand("select * from [" + TableName + "]", conn)) {
    				var da = new SqlDataAdapter(cmd);
    				var dt = new DataTable("MyTable");
    				da.Fill(dt);
    				return dt;
    			}
    
    		}
        }
    
     }
