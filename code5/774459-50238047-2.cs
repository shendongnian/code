    SqlConnection conn = new SqlConnection(func.internalConnection);
    var cmd = new SqlCommand("usp_CustomerPortalOrderDetails", conn);
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customerId;
    cmd.Parameters.Add("@Qid", SqlDbType.VarChar).Value = qid;
    conn.Open();
    
    // Populate Production Panels
    DataTable listCustomerJobDetails = new DataTable();
    listCustomerJobDetails.Load(cmd.ExecuteReader());
    conn.Close();
