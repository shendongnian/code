        private void cmdload_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Point");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            table.Columns.Add("Z");
            table.Columns.Add("R");
            table.Columns.Add("A");
            table.Columns.Add("B");
            table.Columns.Add("C");
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\"; // your directory is also not defined properly
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";// have a look to filter as well
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string filename = openFileDialog1.FileName;
                            using (var reader = File.OpenText(filename)) // you need not to use '@filename' instead use just 'filename'
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    string[] parts = line.Split(' ');
                                    table.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]);
                                }
                                dataGridView1.DataSource = table;
                            }
                        }
                    }
                }
                catch (Exception ex) // you need to add the catch block if yo are using try block
                {
                }
            }
