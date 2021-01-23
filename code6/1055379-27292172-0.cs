    try
            {
                oConnection = new SqlConnection(_connectionString);
                oCommand = new SqlCommand("select * from tbldpt", oConnection);
                oConnection.Open();
                oDataset = new System.Data.DataSet();
                SqlDataReader oReader = oCommand.ExecuteReader();
    
                list<string> _combobox=new list<string>();
                _combobox.add("--Select Department--");
    
                while (oReader.Read())
                {                   
                    _combobox.Add(oReader["Name"].ToString());
                   
                }
    cboDepartment.Datasource=_combobox
             
                oReader.Close();
                oConnection.Close();
            }
            catch(Exception ex)
            {
            }
