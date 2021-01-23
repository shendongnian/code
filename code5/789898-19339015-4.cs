      private void SaveInCSVFILE()
        {
            if (txtName.Text != string.Empty && txtLastName.Text != string.Empty && txtAge.Text != string.Empty && txtAdress.Text != string.Empty && txtContactNumber.Text != string.Empty)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("filename.csv", true))
                { sw.WriteLine(string.Format("{0};{1};{2};{3};{4}", txtName.Text, txtLastName.Text, txtAge.Text, txtAdress.Text, txtContactNumber.Text)); }
                UpdateTable();
            }
            
        }
        private void UpdateTable()
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader("filename.csv"))
            {
                int tmpCountRow = 0;
                while (sr.Peek() > -1)
                {
                    tmpCountRow++;
                    if (tmpCountRow > this.rowCountFile)
                    {
                        AddRow(sr.ReadLine());
                        this.rowCountFile++;
                    }
                    else
                        sr.ReadLine();
                }
            }
        }
        private void ClearDataGridView()
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
        }
        private void AddRow(string s)
        {
            string setRow = string.Empty;
            string[] tmp = s.Split(';');
            setRow = tmp[0] + ';' + tmp[1] + ';' + tmp[2];
            dgv.Rows.Add(setRow.Split(';'));
        }
        private void LoadTable()
        {
            ClearDataGridView();
            dgv.ColumnCount = 3;
            dgv.Columns[0].HeaderCell.Value = "First Name";
            dgv.Columns[1].HeaderCell.Value = "Last Name";
            dgv.Columns[2].HeaderCell.Value = "Age";
            using (System.IO.StreamReader sr=new System.IO.StreamReader("filename.csv"))
            {
                while (sr.Peek() > -1)
                {
                    this.rowCountFile++;
                    while (sr.Peek() > -1)
                    {
                        AddRow(sr.ReadLine());
                    }
                }
            }
        }
