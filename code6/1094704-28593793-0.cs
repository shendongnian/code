    static void Demo(DataGridView dgv)
    {
        string src = @"C:\temp\currentData.txt";
        var data = File.ReadAllBytes(src);
        int nCols = 16; //number of columns to use in the DGV
        DataTable dt = new DataTable();
    
        for (int i = 0; i < nCols; i++)
        {
            dt.Columns.Add(new DataColumn { DataType = Type.GetType("System.Int16") });
        }
    
        var lastIndex = data.Length - nCols - 1;
        for (int i = 0; i < lastIndex; i += nCols * 2)
        {
            var dr = dt.NewRow();
    
            for (int j = 0; j <= nCols * 2 - 1; j += 2)
            {
                dr[j / 2] = BitConverter.ToInt16(data, i + j);
            }
    
            dt.Rows.Add(dr);
        }
    
    
        dgv.DataSource = dt;
    
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        Demo(dataGridView1);
    
    }
        
