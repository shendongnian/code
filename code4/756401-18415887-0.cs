    if (ID_textBox1.Text.Trim().Length > 0)
    {
        try
        {
            query = "SELECT ProductName,ProductDescription,SellPrice FROM Table2 WHERE ProductID=@ProductID";
            using (SqlConnection Conn = CreateConnection.create_connection())
            {
                
                // NOTE: If CreateConnection.create_connection() does not return
                // an opened connection, you will need to open it like this:
                // Conn.Open();
                SqlCommand cd = new SqlCommand(query, Conn);
                cd.Parameters.AddWithValue("@ProductID", ID_textBox1.Text);
                using (SqlDataReader reader = cd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Name_textBox2.Text = reader["ProductName"].ToString();
                        Description_textBox3.Text = reader["ProductDescription"].ToString();
                        Unit_Price_textBox5.Text = reader["SellPrice"].ToString();
                    }
                }
            }
            
            decimal quantity;
            decimal unitPrice;
            QTY_textBox4.Text = "1";
            
            decimal.TryParse(QTY_textBox4.Text, out quantity);
            decimal.TryParse(Unit_Price_textBox5.Text, unitPrice);
            Price_textBox6.Text = (quantity * unitPrice).ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
