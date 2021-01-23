      private void saveInCSVFILE()
        {
            if (txtName.Text != string.Empty && txtLastName.Text != string.Empty && txtAge.Text != string.Empty && txtAdress.Text != string.Empty && txtContactNumber.Text != string.Empty)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("filename.csv", true))
                { sw.WriteLine(string.Format("{0};{1};{2};{3};{4}", txtName.Text, txtLastName.Text, txtAge.Text, txtAdress.Text, txtContactNumber.Text)); }
                updateTable();
            }
            
        }
        private void updateTable()
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            using (System.IO.StreamReader sr = new System.IO.StreamReader("filename.csv"))
            {
                while (sr.Peek() > -1)
                {
                    string setRow = string.Empty;
                    string[] tmp = sr.ReadLine().Split(';');
                    setRow = tmp[0] + ';' + tmp[1] + ';' + tmp[2];
                    dgv.Rows.Add(setRow.Split(';'));
                }
            }
        }
