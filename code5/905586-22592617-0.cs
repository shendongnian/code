     string excelCnString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + 
                            @"Data Source=ExcelFile.xlsx;" + 
                            @"Extended Properties='Excel 12.0;HDR=YES;IMEX=0'"; 
     Dictionary<string,string> dict = new Dictionary<string,string>()
     using(OleDbConnection cn = new OleDbConnection(excelCnString))
     using(OleDbCommand cmd1 = new OleDbCommand("SELECT * FROM [Sheet$]", cn))
     {
          cn.Open();
          using(OleDbDataReader reader = cmd1.ExecuteReader())
          {
              dict.Add(reader[0].ToString(), reader[1].ToString());
          }
     }
