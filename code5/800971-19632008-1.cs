    foreach (DataRow drrow in ds.Tables["A"].Rows)
            { 
            ad.InsertCommand.Parameters.Add(new OracleParameter(":BANK_ID", drrow["BANK_ID"]));
            ad.InsertCommand.Parameters.Add(new OracleParameter(":BANK", drrow["BANK NAME"]));
            ad.InsertCommand.Parameters.Add(new OracleParameter(":IFSC", drrow["IFSC"]));
            ad.InsertCommand.Parameters.Add(new OracleParameter(":BRANCHNAME", drrow["BRANCH NAME"]));
            ad.InsertCommand.Parameters.Add(new OracleParameter(":ADDRESS", drrow["ADDRESS"]));
            ad.InsertCommand.ExecuteNonQuery();
        }
