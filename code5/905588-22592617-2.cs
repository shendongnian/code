     string excelCnString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + 
                            @"Data Source=ExcelFile.xlsx;" + 
                            @"Extended Properties='Excel 12.0;HDR=YES;IMEX=0'"; 
     using(OleDbConnection cn = new OleDbConnection(excelCnString))
     using(OleDbCommand cmd1 = new OleDbCommand("UPDATE [Sheet$] SET COLUMN2 = @V1 WHERE COLUMN1 = @V2", cn))
     {
          cmd1.Parameters.AddWithValue("V1", string.Empty);
          cmd1.Parameters.AddWithValue("V2", string.Empty);
          cn.Open();
          foreach(KeyValuePair<string,string> kvp in dict)
          {
              cmd1.Parameters["V1"] = kvp.Key;
              cmd1.Parameters["V2"] = kvp.Value;
              cmd1.ExecuteNonQuery();
          }
     }
