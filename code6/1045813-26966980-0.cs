            TotalRecords = 0;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    //search on 1st row of datagridview
                    if (row.Cells[1].Value.ToString() == item)
                    {
                        row.Visible = true;
                        TotalRecords += 1;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            dataGridView1.Refresh();
            labelTotalRecords.Text = "Total records = " + TotalRecords.ToString();
        }`
