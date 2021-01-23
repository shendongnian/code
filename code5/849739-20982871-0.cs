    //add columns for the target dates
    DataTable dt2 = new DataTable();
    dt2.Columns.Add("Name", typeof(string));
    for (int n = 1; n < 5; n++)
    {                
        var dataColumn = dt2.Columns.Add(String.Format("12_0{0}_13", n), typeof (int));
        dataColumn.Caption = String.Format("12/0{0}/13", n);                
    }
    DataRow pivotRow = dt2.NewRow();
    foreach (DataRow row in dt1.Rows)   //step through the rows in the source table
    {
        if (pivotRow[0].ToString() != row[0].ToString())   //if this is a "new" name in the data set
        {
            if (pivotRow[0].ToString() != "")  //and it's not the first row of the data set
                dt2.Rows.Add(pivotRow);  //add the row we've been working on
            pivotRow = dt2.NewRow();  //create a new row for the "next" name
            pivotRow[0] = row[0].ToString();  //add the "next" name to the name column
        }
        //match the string date stored in column 2 of the source DataTable to the column name in the target one, replacing the '/', and put the associated int value in that column
        pivotRow[row[2].ToString().Replace("/", "_")] = (int)row[1];
    }
    //once we've finished the whole source DataTable, add the final row to the target DataTable
    dt2.Rows.Add(pivotRow);
