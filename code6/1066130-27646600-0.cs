    public void UpdateGridView(byte[] valueArray)
    {
        //  dataGridView.Visible = false;     // < ==
        dataGridView.SuspendLayout();         // < ==
        DataTable dt = new DataTable();
        dt.Columns.Add("Index");             // < ==
        dt.Columns.Add("Data");
        for (int j = 0; j < valueArray.Length; j++)
        {
            DataRow row = dt.NewRow();
            row[0] = j;                      // < ==
            row[1] = valueArray[j];          // < ==
            //for (int i = 0; i < 1; i++)    // < ==
            //{                              // < ==
            //    row[i] = valueArray[j];    // < ==
            //}                              // < ==
            dt.Rows.Add(row)
           // dataGridView.DataSource = dt;
        }
        dataGridView.DataSource = dt;
        dataGridView.ResumeLayout();         // < ==
        //   dataGridView.Visible = true;    // < ==
    }
