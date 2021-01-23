    void searchNameDbMethod()
    {
        OleDbConnection Myconnection = null;
        OleDbDataReader dbReader = null;
        string selectionText = "";
        string searchName = "";
        Console.Write("Search for Employee Name: ");
        searchName = Console.ReadLine();
        searchName = searchName.ToUpper();
        Console.WriteLine("\n");
        Myconnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= payrolldb.accdb");
        Myconnection.Open();
        selectionText = "SELECT * FROM Table1 WHERE Employee like @Name;";
        OleDbCommand cmd = Myconnection.CreateCommand();
        cmd.CommandText = selectionText;
        cmd.Parameters.Add(new OleDbParameter() { ParameterName = "@Name", Value = searchName, DbType = System.Data.DbType.String });
        try
        {
            dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dbReader.Read())
            {
                // since the query produces one column, the GetValue(0)           
                //must be set                
                // with multiple column queries, you have to know which  
                //column holds
                // the value that you are looking for                     
                //field 0 = ID
                string dbName = dbReader.GetValue(1).ToString();         //1 is field 1 of the db
                if (dbName == searchName)
                {
                    dbName = dbReader.GetValue(1).ToString();         //1 is field 1 of the db
                    string dbID = dbReader.GetValue(2).ToString();    //2 is field 2 of the db
                    string dbHourlyWage = dbReader.GetValue(3).ToString();
                    string dbDependents = dbReader.GetValue(4).ToString();
                    Console.Clear();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("**************** {0} *****************", date);
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Employee Name: ", dbName);
                    Console.WriteLine("Employee ID: {0}", dbID);
                    Console.WriteLine("Hourly Wage: {0}", dbHourlyWage);
                    Console.WriteLine("Number of Dependents: {0}", dbDependents);
                    Console.WriteLine("*******************************************************");
                    Console.ResetColor();
                    Console.Write("\n\n");
                }
            }
        }
        catch
        {
            if (dbReader != null)
            {
                dbReader.Close();
            }
        }
        finally
        {
            if (Myconnection != null)
            {
                Myconnection.Close();
            }
        }
    }
