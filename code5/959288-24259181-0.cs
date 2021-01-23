    DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                openFileDialog1.ShowDialog();
                string connectionString = string.Format("Provider = Microsoft.Jet.OLEDB.4.0;Data Source ={0};Extended Properties = Excel 8.0;", this.openFileDialog1.FileName);
                var con = new OleDbConnection(connectionString);
                var cmd = new OleDbCommand("select * from [sheet1$] where [MRN#]=@c", con);
                cmd.Parameters.Add("@c", "33264");
                con.Open();
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataGridView dv = new DataGridView();
                this.Controls.Add(dv);
                dv.DataSource = dt;
            }
        }
