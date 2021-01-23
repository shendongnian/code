    private void getData(string selectquery)
        {
            try
            {
                // string qryText1 = @"SELECT FEE_HEAD.FEE_HEAD_NAME, FEE_AMOUNT.FEE_HEAD_AMOUNT, FEE_AMOUNT.CLASS_ID FROM FEE_AMOUNT INNER JOIN FEE_HEAD ON FEE_AMOUNT.FEE_HEAD_ID = FEE_HEAD.ID";
                SqlConnection con = new SqlConnection(@"Data Source=392;User id=sa; Password=manage@123;Initial Catalog=Benefit;Pooling=False");
                SqlCommand command = new SqlCommand(selectquery, con);
                con.Open();
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
                dataAdapter1.SelectCommand = command;
                DataTable dataT = new DataTable();
                dataAdapter1.Fill(dataT);
                BindingSource bs = new BindingSource();
                bs.DataSource = dataT;
                dataGridView1.DataSource = bs;
                dataAdapter1.Update(dataT);
                dataGridView1.Refresh();
                con.Close();
            }
            catch (SqlException ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }
