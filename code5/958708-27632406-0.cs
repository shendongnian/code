    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
     {
        if (dataGridView1.CurrentCell.ColumnIndex == 1)
          {
            SqlDataReader dreader;    
            AutoCompleteStringCollection MyCollection1  = new AutoCompleteStringCollection();
            AutoCompleteStringCollection MyCollection2 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection MyCollection3 = new AutoCompleteStringCollection();
            cmd =new SqlCommand( "Select * from SUP_PRO",conn);
            conn.Open();
             dreader = cmd.ExecuteReader();
             if (dreader.HasRows == true)
              {
                  while (dreader.Read())
              MyCollection1.Add(dreader["P_name"].ToString());
              MyCollection2.Add(dreader["P_ProName"].ToString());
              MyCollection3.Add(dreader["P_rate"].ToString());
          }
                else
                {
                    MessageBox.Show("Data not Found");
                }
                dreader.Close();
            
                TextBox Product = e.Control as TextBox;
                if (Product != null)
                {
                    Product.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    Product.AutoCompleteCustomSource = MyCollection1;
                    Product.AutoCompleteSource = AutoCompleteSource.CustomSource;
                Product.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Product.AutoCompleteCustomSource = MyCollection2;
                Product.AutoCompleteSource = AutoCompleteSource.CustomSource;
                Product.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Product.AutoCompleteCustomSource = MyCollection3;
                Product.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
