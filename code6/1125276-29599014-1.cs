    private void PrintPreview()
    {
        try
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("DATA ROW KOSONG", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var table = new DataTable("V_KARYAWAN, KARYAWAN_GAMBAR");
                //Create columns in table form gridView1.
                foreach (GridColumn column in gridView1.Columns)
                    table.Columns.Add(column.FieldName, column.ColumnType);
                //Export gridView1 to table.
                for (int rowHandle = 0; rowHandle < gridView1.DataRowCount; rowHandle++)
                {
                    var row = table.NewRow();
                    foreach (DataColumn column in table.Columns)
                        row[column] = gridView1.GetRowCellValue(rowHandle, column.ColumnName);
                    table.Rows.Add(row);
                }
                //Show report.
                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                kartu report = new kartu();
                report.DataSource = ds.Tables[0];
                report.ShowPreview();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
