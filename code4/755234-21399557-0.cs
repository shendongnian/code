        private void buttonLoad_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            System.Threading.Thread thread = 
              new System.Threading.Thread(new System.Threading.ThreadStart(loadTable));
            thread.Start();
        }
        private void loadTable()
        {
            // Load your Table...
            DataTable table = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter();
            SDA.Fill(table);
            setDataSource(table);
        }
        internal delegate void SetDataSourceDelegate(DataTable table);
        private void setDataSource(DataTable table)
        {
            // Invoke method if required:
            if (this.InvokeRequired)
            {
                this.Invoke(new SetDataSourceDelegate(setDataSource), table);
            }
            else
            {
                dataGridView.DataSource = table;
                progressBar.Visible = false;
            }
        }
