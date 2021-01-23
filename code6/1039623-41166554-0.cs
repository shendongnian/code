    foreach ( DataGridViewColumn dc in DataGridView1.Columns)
    {
        if (dc.ValueType == typeof(Boolean))
        {
            dc.ValueType = typeof(Int32);
            ((DataGridViewCheckBoxColumn)dc).DefaultCellStyle.NullValue = 0;
            ((DataGridViewCheckBoxColumn)dc).TrueValue = 1;
            ((DataGridViewCheckBoxColumn)dc).FalseValue = 0;
        }
    }
