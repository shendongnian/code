    private void memberID(object sender, EventArgs e)
    {
        int value = deptCmbBox; // if this is a combobox, you'll probably need to cast its SelectedText, SelectedValue or SelectedItem property to an integer
        int numZeroes = ??; // you'll have to give this a value or it'll return NULL
        
        string result = GetMemberID(value, numZeroes); // you'll have to decide how to store/use the resulting string here
    }
    private string GetMemberID(int value, int numberOfZeroes)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EPRAISE-PC;Initial Catalog=master;Integrated Security=True");
        SqlCommand comm = new SqlCommand();
        SqlParameter param;
        string result;
        comm.CommandText = "SELECT dbo.ufnLeadingNumberOfZeroes(@Value, @NumberOfZeroes)";
        comm.CommandType = CommandType.Text;
        comm.Connection = conn;
        // Create and add the @Value parameter
        param = new SqlParameter();
        param.ParameterName = "@Value";
        param.Direction = ParameterDirection.Input;
        param.SqlDbType = SqlDbType.Int;
        param.Value = value;
        comm.Parameters.Add(param);
        // Create and add the @NumberOfZeros parameter
        param = new SqlParameter();
        param.ParameterName = "@NumberOfZeroes";
        param.Direction = ParameterDirection.Input;
        param.SqlDbType = SqlDbType.Int;
        param.Value = numberOfZeroes;
        comm.Parameters.Add(param);
        try
        {
            conn.Open();
            result = comm.ExecuteScalar().ToString();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally // clean up after yourself
        {
            comm.Dispose();
            conn.Dispose(); // also closes the connection just in case it's left open
        }
        
        return result;
    }
