    SqlConnection sqlConn = new SqlConnection(connection string here);
    SqlCommand sqlComm = new SqlCommand();
    sqlComm = sqlConn.CreateCommand();
    sqlComm.CommandText = @"UPDATE Users SET first_name = @firstname WHERE ID = @id";
    sqlComm.Parameters.Add("@firstname", SqlDbType.VarChar);
    sqlComm.Parameters["@firstname"].Value = txt_firstname.Text;
    sqlComm.Parameters.Add("@id", SqlDbType.VarChar);
    sqlComm.Parameters["@id"].Value = HTTPContext.Current.Session["ColumnID"].ToString();
    sqlConn.Open();
    sqlComm.ExecuteNonQuery();
    sqlConn.Close();
 
