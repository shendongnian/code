    // Assumes that conn is a valid SqlConnection object.
    string strquery = "select * from tblclientinfo where clientId=" + txtid.Text;
    SqlDataAdapter adapter = new SqlDataAdapter(strquery , conn);
    
    DataSet resultSet = new DataSet();
    resultSet.Fill(resultSet, "resultSet");
    //now you can read data from DataTables contained in your dataset and do whatever with it
    DataTable FirstTableOfDataSet = resultSet.Tables[0];
