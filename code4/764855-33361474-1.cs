    try
            {
                con = new SqlConnection(cs.ConDB);
                con.Open();
                cmd = new SqlCommand(@"SELECT RTRIM(sno)as [sno],RTRIM(currDate) as [currDate],
                RTRIM(WtrNm) as [WtrNm],RTRIM(Type) as [Type],(No ) as [No] from WtrTblAllot where currDate like '" + currDate.Text + "%' order by currDate", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet WtrTblAllot = new DataSet();
                myDA.Fill(WtrTblAllot , "WtrTblAllot ");
                dataGridView1.DataSource = WtrTblAllot .Tables["WtrTblAllot "].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
