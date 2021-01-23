    if ((int)Dts.Variables["User::totalCount"].Value == 0)    // if the total count variable has not been initialized...
            {
                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                DataTable stagingTablesQryResult = new DataTable();
                da.Fill(stagingTablesQryResult, Dts.Variables["User::stagingTablesQryResultSet"].Value);    // to be used for logging how many files are we iterating. It may be more efficient to do a count(*) outside this script and save the total number of rows for the query but I made this as proof of concept for future developments.
                Dts.Variables["User::totalCount"].Value = stagingTablesQryResult.Rows.Count;
            }
    Console.WriteLine("{0}. Looking for data file {0} of {1} using search string '{2}'.", counter, Dts.Variables["User::totalCount"].Value, fileNameSearchString);
