    var col1 = new DataGridViewTextBoxColumn()
    {
       HeaderText = "Month",
       Width = 40,
       DefaultCellStyle = new DataGridViewCellStyle()
       {
          Alignment = DataGridViewContentAlignment.MiddleCenter,
          ForeColor = System.Drawing.Color.Black
       }
    };
    
    dataGridView.Columns.Add(col1);
