    string strName = dtTable.Rows[i][myName].ToString();
    string selectBrand = "SELECT [brand] FROM [myTable] WHERE [myName] = @name";
    
    using(SqlCommand sqlCmdSelectBrand = new SqlCommand(selectBrand , sqlConn))
    {
        sqlCmdSelectBrand.Parameters.Add(
                 new SqlParameter("@name", SqlDbType.NVarChar)).Value = strName;
        sqlCmdSelectBrand .Connection.Open();
        using(SqlDataReader reader = sqlCmdSelectBrand.ExecuteReader())
        {
            if(reader.HasRows)
            {
               reader.Read();
               string newBrand = reader.GetString(reader.GetOrdinal("Brand"));
               ..... work with the string newBrand....
            }
            else
                // Message for data not found...
    
            sqlCmdSelectBrand .Connection.Close();
        }
    }
