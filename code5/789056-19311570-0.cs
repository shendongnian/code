    StreamWriter sW = new StreamWriter(dirLocationString);
    
    for (int row = 0; row< numRows1; row++){
        string lines = "";
        for (int col = 0; col < 4; col++)
        {
            lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dataGridView1.Rows[row].Cells[col].Value.ToString();
        }
    
        sW.WriteLine(lines);
    }
    
    sW.Close(); 
