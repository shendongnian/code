DataSet objDataSet = new DataSet();
SqlConnection objConn = new SqlConnection();
string query = "";//Your query here
SqlCommand objComm = new SqlCommand(query, objConn);
SqlDataAdapter objDataAdapter = new SqlDataAdapter(objComm);
if (objConn.State == ConnectionState.Closed)
{
    objConn.Open();
}
objDataAdapter.Fill(objDataSet, "YourTableName");
dataGridView1.DataSource = objDataSet;
