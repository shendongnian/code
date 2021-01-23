            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dtCompanyInfo = GetCompanyInfo();
            if (dtCompanyInfo.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtCompanyInfo;
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "";
                checkColumn.HeaderText = "Select";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values\\
                dataGridView1.Columns.Add(checkColumn);
            }
        }
