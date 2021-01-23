    conn =  new 
    	SqlConnection("ConnectionString");
    conn.Open();
    
    SqlCommand cmd = new SqlCommand(
    	"SELECT * from tenant WHERE (name LIKE %@tenant%)", conn);
    SqlParameter param  = new SqlParameter();
    param.ParameterName = "@tenant";
    param.Value         = txtSearchRP.Text;
    cmd.Parameters.Add(param);
    SqlDataReader reader = cmd.ExecuteReader();
