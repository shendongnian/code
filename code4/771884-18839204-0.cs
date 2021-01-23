    public void ReadDataGridView(int ProcessId)
    {
        ProgramToWatchDataGrid updateGrid = null;
    
        //read and store every row
        int i=0;
        while(i<=totalRowsInGrid)
        {
            //create a new instance
            updateGrid = new ProgramToWatchDataGrid();
            updateGrid.ListId = DataGrid.Rows[i].Cells[0].Value;
            updateGrid.Name = DataGrid.Rows[i].Cells[1].Value;
            updateGrid.Mail = DataGrid.Rows[i].Cells[2].Value;
    
            ProgramToWatchDictionary[ProcessID].BEDataGrid.Insert(i, updateGrid);
            Display(ProgramToWatchDictionary[ProcessID].BEDataGrid[i].Mail);
        }
    
        Display("Elements: " + ProgramToWatchDictionary[ProcessID].BeDataGrid.Count);
    
        //display every rows mail
        i=0;
        while(i<=totalRowsInGrid)
        {
            Display("HI: " + ProgramToWatchDictionary[ProcessID].BEDataGrid[i].Mail);
            i++;
        }
    }
