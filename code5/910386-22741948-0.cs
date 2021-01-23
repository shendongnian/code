        private void buttonCloseCart_Click(object sender, EventArgs e)
        {
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\אורון\documents\visual studio 2012\Projects\CachierPro\CachierPro\CachierProDB.accdb";
            connect.Open();
            OleDbCommand cmd = new OleDbCommand(@"INSERT INTO Receipts 
            (ItemName, Quantity, PricePerOne, Total) 
             VALUES (@temp_item, @temp_item_quantity, 
             @temp_item_price, @temp_total_item_price)", connect);
 
             cmd.Parameters.Add ("@temp_item", OleDbType.Char, 20);
             cmd.Parameters.Add("@temp_item_quantity", OleDbType.Integer, 20);
             cmd.Parameters.Add("@temp_item_price", OleDbType.Double, 20);
             cmd.Parameters.Add("@cart_sum", OleDbType.Double,20);
            for (int i = 0; i < baught_items.Count; i++)
            {
                string temp_item = baught_items[i].ToString();
                int temp_item_quantity = baught_items_quantity[i];
                double temp_item_price = baught_items_price[i];
                double temp_total_item_price = total_items_price[i];
                if (connect.State == ConnectionState.Open)
                {
                    cmd.Parameters["@temp_item"].Value = temp_item;
                    cmd.Parameters["@temp_item_quantity"].Value = temp_item_quantity;
                    cmd.Parameters["@temp_item_price"].Value = temp_item_price;
                    cmd.Parameters["@cart_sum"].Value = temp_total_item_price;
                    try
                    {
                        int addedCount = cmd.ExecuteNonQuery();
                        if(addedCount == 0)
                        {
                           ... problems here, record not added for some reasons
                        }
                    }
                    catch (Exception expe)
                    {
                        MessageBox.Show(expe.Source);
                        connect.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                }
            }
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = new OleDbCommand("SELECT * FROM Receipts", connect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            textBoxCurrentCartSumTXT.Clear();
            textBoxPricePerOneTXT.Clear();
            textBoxQuantityTXT.Clear();
            textBoxSumForCurrentItemTXT.Clear();
            connect.Close();
       }
