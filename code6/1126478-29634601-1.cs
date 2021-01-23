    SqlCommand sqlComm = new SqlCommand();
    sqlComm.CommandText = @"UPDATE Users SET first_name = @firstname WHERE ID = @id";
    sqlComm.Parameters.Add("@firstname", SqlDbType.VarChar);
    sqlComm.Parameters["@firstname"].Value = txt_firstname.Text;
    sqlComm.Parameters.Add("@id", SqlDbType.VarChar);
    sqlComm.Parameters["@id"].Value = HTTPContext.Current.Session["ColumnID"].ToString();    
    using (SqlConnection sqlConn = new SqlConnection(connection string here);)
    {
        sqlComm.Connection = sqlConn;
        sqlConn.Open();
        sqlComm.ExecuteNonQuery();
    }
 
