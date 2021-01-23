        void Auto_Complete()
        {
            txtAutoProductCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAutoProductCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlCeCommand com = new SqlCeCommand("SELECT ProductCode FROM Products_Master", con);
            SqlCeDataReader dr;
            con.Open();
            try
            {
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    string aProduct = dr.GetString(0);
                    coll.Add(aProduct);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtAutoProductCode.AutoCompleteCustomSource = coll;
            con.Close();
        }
