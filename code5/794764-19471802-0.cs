    if (!System.IO.File.Exists("file.txt"))
                return;
            dgvDataGridView.ColumnCount = 4;
            dgvDataGridView.Columns[0].HeaderCell.Value = "ID";
            dgvDataGridView.Columns[1].HeaderCell.Value = "Author";
            dgvDataGridView.Columns[2].HeaderCell.Value = "Caption";
            dgvDataGridView.Columns[3].HeaderCell.Value = "Categories";
            using (System.IO.StreamReader sr = new System.IO.StreamReader("file.txt"))
                while (sr.Peek() > -1)
                    dgvDataGridView.Rows.Add(sr.ReadLine().Split(','));
