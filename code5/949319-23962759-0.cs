    enter public static string ReturnDefinition(string remCode)
        {
            string strReturnMessage = "";
            string excelConnectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MEDICARE.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES""";
            string excelSheet = "Sheet1$";
            OleDbConnection objConn = new OleDbConnection(excelConnectString);
            OleDbCommand excelCmd = new OleDbCommand("Select * from ["+ excelSheet + "] where Code = @remCode", objConn);
            excelCmd.Parameters.AddWithValue("@remCode", remCode);
            try
            {
                objConn.Open();
                OleDbDataReader ExcelDataReader = excelCmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (ExcelDataReader.HasRows)
                {
                    while (ExcelDataReader.Read())
                    {
                        if (string.IsNullOrEmpty((string)ExcelDataReader["Description"]))
                        {
                            strReturnMessage = "** ERROR **";
                        }
                        else
                        {
                            strReturnMessage = ExcelDataReader["Description"].ToString();
                        }
                    }
                }
                else
                {
                    strReturnMessage = "** ERROR **";
                }
                ExcelDataReader.Close();
                return strReturnMessage;
            }
            catch (Exception ex)
            {
                return "** ERROR **: " + ex.Message;
            }
            finally
            {
            }
        }
