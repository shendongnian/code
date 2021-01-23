    // Make the table available outside the if-else, even if it is empty:
    datTable = new DataTable(); 
    if (sender == form1.filterType())
    {
        val = (sender as TextBox).Text;
        //havent written the whole SQL Command here
        sqlCmd = new SqlCommand("SELECT * FROM, connection); 
            
        // Only do this if it is relevant, i.e. here within the if-structure,
        // that way, you should be able to avoid the nullRef:
        sqlDatAdapter = new SqlDataAdapter(sqlCmd.CommandText, connection); 
        sqlDatAdapter.Fill(datTable);
    }
    // You might have to check something extra here, depending on
    // usage, since the table might be empty:
    form1.setDataGrid = datTable;
