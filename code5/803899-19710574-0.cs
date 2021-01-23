    try
            {
                connection.Open();
    
    
    
                da.Fill(ds);
                DataRow item = ds.Tables[0].Rows[0];
                byte[] item1 = (byte[])item["FileImage"];
                ds.Tables.Clear();
                numArray = item1;
    
    
            }
            catch (Exception ex)
            {
                MessageBox.Show("My error description");
    // or write the message to a textBox.
            }
            finally
            {
                connection.Close();
            }
            return numArray;
        }
