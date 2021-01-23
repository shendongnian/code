        string constring = @"Data Source=|DataDirectory|\LWADataBase.sdf";
        string Query = "UPDATE stockTBL SET Quantity = Quantity + @quantity where [Item Name] = @name";
        using(SqlCeConnection conDataBase = new SqlCeConnection(constring))
        using(SqlCeCommand cmdDataBase = new SqlCeCommand(Query, conDataBase))
        {
            cmdDataBase.Parameters.AddWithValue("@quantity", int.Parse(quantityTxt.Text));
            cmdDataBase.Parameters.AddWithValue("@name", itemTxt.Text);
            conDataBase.Open();
            cmdDataBase.ExecuteNonQuery();
            cmdDataBase.Close();
        }
