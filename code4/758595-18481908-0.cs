    public void searchNameDbMethod()
        {
            OleDbConnection Myconnection = null;
            OleDbDataReader dbReader = null;
            string selectionText = "";
            bool errorFlag = true;
            do
            {
                string searchName = "";
                Console.Write("Search for Employee Name: ");
                searchName = Console.ReadLine();
                searchName = searchName.ToUpper();
                Console.WriteLine("\n");
                Myconnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= payrolldb.accdb");
                Myconnection.Open();
                selectionText = "SELECT * FROM Table1 WHERE employee_name='" + searchName + "'";
                OleDbCommand cmd = Myconnection.CreateCommand();
                cmd.CommandText = selectionText;
                dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        // since the query produces one column, the GetValue(0)           
                        //must be set                
                        // with multiple column queries, you have to know which  
                        //column holds
                        // the value that you are looking for                     
                        //field 0 = ID
                        dbName = dbReader.GetValue(1).ToString();         //1 is field 1 of the db
                        if (dbName == searchName)
                        {
                            dbName = dbReader.GetValue(1).ToString();         //1 is field 1 of the db
                            dbID = dbReader.GetValue(2).ToString();    //2 is field 2 of the db
                            dbHourlyWage = dbReader.GetValue(3).ToString();
                            dbDependents = dbReader.GetValue(4).ToString();
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
                            errorFlag = false;
                        }//closes if             
                    }// end of while
                }// end of if
                else if (!dbReader.HasRows)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name is not in our database!");//shows the data accumulated from above       
                    Console.ResetColor();
                }//closes if
                dbReader.Close();
                Myconnection.Close();
            }//close do
            while (errorFlag == true);
        }//closes searchNameDbMethod
    
