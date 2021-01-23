    DataTable DT_ExcludeNo = new DataTable();
    dataAdapter.Fill(DT_ExcludeNo);
    InsertLogFile("AMB SP15: Validate Insert Data");
    //start new code
    string fieldString = x[0].ToString();
    if (string.IsNullOrEmpty(fieldString))
    {
       fieldString = "0";
    }
    //InsertLogFile("AMB SP15: Execute Query: " + sSqlCommandRetrieveExcludeNO);
    List<Int32>    ListintNo = DT_ExcludeNo.AsEnumerable().Select(x =>   Convert.ToInt32(fieldString )).ToList();
    //end new code
         DataTable DT_ExcludeNo = new DataTable();
         dataAdapter.Fill(DT_ExcludeNo);
         InsertLogFile("AMB SP15: Validate Insert Data");
         //InsertLogFile("AMB SP15: Execute Query: " + sSqlCommandRetrieveExcludeNO);
            string fieldString = x[0].ToString();
            if (string.IsNullOrEmpty(fieldString))
            { fieldString = "0"; }
         List<Int32> ListintNo = DT_ExcludeNo.AsEnumerable().Select(x => Convert.ToInt32(fieldString)).ToList();
        
            
            
            for (Int32 i = 1; i <= TotalCount; i++)
        {
            foreach (Int32 intNo in ListintNo)
            {
                if (i == intNo)
                {
                string sSqlCommandRetrieveData = "SELECT Name, [I.C], [D.O.B], NO, [EFF DATE], Sum_Insured from AMB_Temp WHERE NO = " + i;
                SqlCommand obj_SQLCommand = new SqlCommand(sSqlCommandRetrieveData, myconn);
                dataAdapter = new SqlDataAdapter(obj_SQLCommand);
                DataSet DS_RetrieveData = new DataSet();
                dataAdapter.Fill(DS_RetrieveData);
                //InsertLogFile("AMB SP15: Execute Query: " + sSqlCommandRetrieveData);
                DataValidation(DS_RetrieveData);
                }
