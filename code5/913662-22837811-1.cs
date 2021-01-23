     public DataSet ShowUsers()
        {
            DataSet op = new DataSet();
            SqlConnection objconnection = new SqlConnection(obj.strconnection());
            SqlCommand objcommand = new SqlCommand();
            DataSet objdataset = new DataSet();
            SqlDataAdapter objdataadapter = new SqlDataAdapter();
            objdataadapter.SelectCommand = objcommand;
            objdataadapter.SelectCommand.Connection = objconnection;
            objdataadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            objdataadapter.SelectCommand.CommandText = "ShowUsers";
            objdataadapter.Fill(objdataset, "sheet");
            return objdataset;
        }
    
