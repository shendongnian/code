    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            using(SqlConnection con = new SqlConnection(....))
            using(SqlCommand sc = new SqlCommand(@"select Profcode, Profname, Profcharges,  
                                         Profduedate from Profnames$ 
                                         Where Profname =  @name", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@name",comboBox1.Text);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                
                DataTable ds = new DataTable();
                sda.Fill(ds);
                if(currentData == null)
                {
                    currentData = ds.Copy();
                    dataGridView2.DataSource = currentData;
                }
                else
                {
                    currentData.BeginLoadData();
                    foreach(DataRow row in ds.Rows)
                       currentData.LoadDataRow(row.ItemArray, true);
                    currentData.EndLoadData();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }    
