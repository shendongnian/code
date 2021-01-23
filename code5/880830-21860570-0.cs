    var arr = new int[5, 3];  // array is just for example
    var columnCount = arr.GetUpperBound(1)+1;
    var rowCount = arr.GetUpperBound(0)+1;
    
    for (int i = 0; i < columnCount; i++)
    {
        dataGridView1.Columns.Add(i.ToString()," ");
    }
    for (int i = 0; i < rowCount; i++)
    {
        dataGridView1.Rows.AddCopy(0);
        for (int k = 0; k < columnCount; k++)
        {
            dataGridView1.Rows[i].Cells[k].Value = arr[i, k];
        }
                
    }
