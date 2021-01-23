    public static void UploadFromExtrernalSource(PlantAreaCode_CreateView PACCreate)
    {
        // For each row in the DataGrid, and for each column, stores the information in a string.
        String value = String.Empty;
        for (int rows = 0; rows < PACCreate.dataGridView1.Rows.Count; rows++)
        {
            for (int col = 0; col < PACCreate.dataGridView1.Rows[rows].Cells.Count; col++)
            {
             if(PACCreate.dataGridView1.Rows[rows].Cells[col].Value!=null)
             value=PACCreate.dataGridView1.Rows[rows].Cells[col].Value;
             else 
             value=String.Empty;
             
             Console.Write(value + ",");
            }
             Console.WriteLine();//it prints a new line 
        }
    }
