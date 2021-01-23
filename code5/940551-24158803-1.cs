    var destinationFile = @"c:\insert.csv";
                    
                    var querieImportCSV = "BULK INSERT dbo.TABLE FROM '" + destinationFile + "' WITH ( FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', FIRSTROW = 1)";
                    var truncate = @"TRUNCATE TABLE dbo.TABLE";
                  string queryResult =
          @"SELECT [Year]
                  ,[Month]
                  ,[Week]
                  ,[Entity]
                  ,[Account]
                  ,[C11]
                  ,[C12]
                  ,[C21]
                  ,[C22]
                  ,[C3]
                  ,[C4]
                  ,[CTP]
                  ,[VALUTA]
	              ,SUM(AMOUNT) as AMOUNT
                  ,[CURRENCY_ORIG]
                  ,[AMOUNTEXCH]
                  ,[AGENTCODE]
	            FROM dbo.TABLE
	            GROUP BY YEAR, MONTH, WEEK, Entity, Account, C11, C12, C21, C22, C3, C4, CTP, VALUTA, CURRENCY_ORIG, AMOUNTEXCH, AGENTCODE
	            ORDER BY Account";
                    var conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand commandTruncate = new SqlCommand(truncate, conn);
                    commandTruncate.ExecuteNonQuery();
                    SqlCommand commandInsert = new SqlCommand(querieImportCSV, conn);
                    SqlDataReader readerInsert = commandInsert.ExecuteReader();
                    readerInsert.Close();
                    FillData();
                    
                    SqlCommand commandResult = new SqlCommand(queryResult, conn);
                    SqlDataReader readerResult = commandResult.ExecuteReader();
                    StringBuilder sb = new StringBuilder(); 
                    while (readerResult.Read())
                    {
                            sb.Append(readerResult["Year"] + ";" + readerResult["Month"] + ";" + readerResult["Week"] + ";" + readerResult["Entity"] + ";" + readerResult["Account"] + ";" +
                            readerResult["C11"] + ";" + readerResult["C12"] + ";" + readerResult["C21"] + ";" + readerResult["C22"] + ";" + readerResult["C3"] + ";" + readerResult["C4"] + ";" +
                            readerResult["CTP"] + ";" + readerResult["Valuta"] + ";" + readerResult["Amount"] + ";" + readerResult["CURRENCY_ORIG"] + ";" + readerResult["AMOUNTEXCH"] + ";" + readerResult["AGENTCODE"]);
                    }
                    sb.Replace("\"","");
                    
                    StreamWriter sw = new StreamWriter(homedrive);
                    sw.WriteLine(sb);
                    readerResult.Close();
                    conn.Close();
                    sw.Close();
                    sw.Dispose();
