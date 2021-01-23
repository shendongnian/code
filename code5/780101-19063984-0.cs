    int columnsCount;
    var writer = new StreamWriter("test.csv");
    //get number of columns
    columnsCount = dataGridview.Columns.Count;
    for (int i = 0; i < columnsCount - 1; i++)
    { 
        writer.Write(dataGridview.Columns[i].Name.ToString().ToUpper() + ",");
    } 
    writer.WriteLine();
    //write on excel
    for (int i = 0; i < (dataGridview.Rows.Count - 1); i++)
    { 
        for (int j = 0; j < columnsCount; j++)
        { 
            if (dataGridview.Rows[i].Cells[j].Value != null)
            {
                writer.Write(dataGridview.Rows[i].Cells[j].Value + ",");
            }
            else 
            {
                writer.Write(",");
            }
        }
        writer.WriteLine();
    }
    //close file
    writer.Close();
