        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(String.IsNullOrEmpty(txtBarcode.Text)) 
                {
                    MessageBox.Show("Please Fill the correct ProductID");
                } 
                else 
                {
                     string sql = "Select * From tblindividualproduct where ProductID = @ProductIdText";
 
                     using (var adapt = new MySqlDataAdapter(sql, conn))
                     using (var cmd = new MySqlCommandBuilder(adapt)) //Not sure what you need this for unless you are going to update the database later.
                     {
                         adapt.SelectCommand.Parameters.AddWithValue("@ProductIdText", txtBarCode.Text);
                         BindingSource bs = new BindingSource();
                         adapt.Fill(dt);
                         bs.DataSource = dt;
                         dgItems.ReadOnly = true;
                         dgItems.DataSource = bs;
                     }
                }
            }
        }
