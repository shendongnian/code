    DataGridView CreateDataGridDynamically(int NumberOfCol)
    {
        DataGridView D = new DataGridView();
        for (int i = 0; i < NumberOfCol; i++)
        {
    
            DataGridViewTextBoxColumn C1 = new DataGridViewTextBoxColumn();
            C1.HeaderText = "Something";
            D.Columns.Add(C1);
        }
        return D;
    }
