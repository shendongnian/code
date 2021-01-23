    AnnualSpend annualSpend; //already populated 
    DataSet dataSet;
    private void PopulateDataSet()
    {
        dataSet = new DataSet();
            
        foreach (ushort yr in annualSpend.Keys)
        {
            Year year = annualSpend[yr];
            DataTable tableOfYear = new DataTable(yr.ToString()); //as key to access the Table
            //Adding columns
            List<string> columnNames = new List<string>();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames.Add(column.Name);
                column.DataPropertyName = column.Name; //!!!Important!!!
                tableOfYear.Columns.Add(new DataColumn(column.Name));
            }           
            //Adding rows            
            DataRow newRowForFoodExpense = tableOfYear.NewRow();
            //then 4 data rows for other expense categories...
            //DataRow newRowForHouseRent = tableOfYear.NewRow();
            for (int m = 0; m < columnNames.Count; m++)
            {
                newRowForFoodExpense[columnNames[m]] = year[(AcceptableMonths)m].Food;   
                //then 4 data rows for other expense categories...              
            }
            
            tableOfYear.Rows.Add(newRowForFoodExpense);
            //then 4 data rows for other expense categories... 
            dataSet.Tables.Add(tableOfYear);
        }
    }
