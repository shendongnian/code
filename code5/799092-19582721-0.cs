            try
            {
                SqlCeCommand com = new SqlCeCommand("select CategoryName from Category_Master", con);
                SqlCeDataReader dr = com.ExecuteReader();
                while(dr.Read()){
                    string name = dr.GetString(0);
                    cmbProductCategory.Items.Add(name);
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
