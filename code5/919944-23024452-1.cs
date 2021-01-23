    public static void Main()
    {
     Datatable myDataTable = new DataTable();
     myDataTable.Columns = new Columns[3];
     myDataTable.Columns[0].ColumnName = "Employees";
     myDataTable.Columns[1].ColumnName = "Salary"
     myDataTable.Columns[2].ColumnName = "Department"
     UpdateOrSaveItems(myDataTable);
 
    }
