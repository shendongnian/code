    try
    {
        //Declare variables
        object rowIndex = 2; //Row to start on. Change to 1 if you do not have header text
        DataRow row;
        System.Data.DataTable dt = new System.Data.DataTable();
        int index = 0;
    
        //Manual column headers - set up for if you are not using the provided column headers
        dt.Columns.Add("Column Name"); //row[0]
        dt.Columns.Add("Column 2"); //row[1]
        dt.Columns.Add("Column 3"); //row[2]
        dt.Columns.Add("Column 4"); //row[3]
    
        //Now for actually reading the values
        while (((Excel.Range)xlWorksheet.Cells[rowIndex, 1])Value2 != null)
        {
            row = dt.NewRow();
    
            //row[column#]
            //for cells[rowIndex, 1]: rowIndex is the row you are reading from, 1 is the source column. This is where you would ignore columns altogether if you needed to.
            //Value2 returns the value of the cell. I don't remember what Value1 returns (cell type?)
            row[0] = Convert.ToString(((Excel.Range)xlWorksheet.Cells[rowIndex, 1]).Value2);
    
            //You can use a switch statement
            //Notice, column index is 3, which means I have effectively skipped column 2
            string valColumn2 = Convert.ToString(((Excel.Range)xlWorksheet.Cells[rowIndex, 3]).Value2);
            switch (valColumn2)
            {
                case "false":
                {
                    row[1] = "0";
                    break;
                }
                case "true":
                {
                    row[1] = "1";
                    break;
                }
                default:
                {
                    row[1] = valColumn2;
                    break;
                }
            }
    
            //You can use a date. OADate assumes it's Excel's date format, which is a double.
            //Note that my column index is 2, the column I skipped before. This shows you can collect data from columns in a non-numeric order.
            try
            {
                row[2] = DateTime.FromOADate(((Excel.Range)xlWorksheet.Cells[rowIndex, 2]).Value2);
            }
            catch //In case it's not a date for some reason- i.e. you hand it a header row.
            {
                row[2] = "";
            }
            
            //You can also display cell values as integers. Say you have a column with a count of items. Additionally, ToInt32 recognizes null values and displays them as 0
            row[3] = Convert.ToInt32(((Excel.Range)xlWorksheet.Cells[rowIndex, 3]).Value2);
    
            //We're done, just a few things to wrap up...
            index++;
            rowIndex = 2 + index; //The initial value of row index is 2. When we reach this point in the first run, index changes to 1, so rowIndex = 2 + 1 = 3
            dt.Rows.Add(row); //Add the row to our datatable
    
            //Optional - if you want to watch each row being added. If not, put it outside of the while loop.
            dataGridView1.DataSource = dt;
        }
    }
    finally
    {
        //Release all COM RCWs.
        //releaseObject will do nothing if null is passed, so don't worry if it's null
        //If you do not release the objects properly (like below), you WILL end up with ghost EXCEL.EXE processes.
        //This will cause runtime errors (unable to access file because it's already open), as well as cause some serious lag once you get enough of them running.
        releaseObject(xlWorksheet);
        releaseObject(xlWorkbook);
        if (xlApp != null)
            { xlApp.Quit(); }
        releaseObject(xlApp);
    }
