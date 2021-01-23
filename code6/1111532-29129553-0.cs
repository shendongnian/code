     private void combomedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            combocompany.Items.Clear();
            GetAutoCombobox_filled();
        }
      //Helper method
        public void GetAutoCombobox_filled()
        {
            // int select_item;
            string str = "select med_name,mnf_name,mfg_date,exp_date from  tbl_mdcnentry";
            command.Connection = connection;
            command.CommandText = str;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                if (combomedicine.SelectedItem.ToString() == (string)reader["med_name"])
                {
                    combocompany.Items.Add(reader.GetValue(1).ToString());
                    dateTimePicker2.Text=reader.GetValue(2).ToString();
                    dateTimePicker3.Text = reader.GetValue(3).ToString();
                    break;
                }
            }
            reader.Close();
        
        
        }
