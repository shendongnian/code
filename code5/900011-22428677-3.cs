    public void stock()
        {
            MySqlConnection con;
            DataTable p_table = new DataTable();
            con = new MySqlConnection("Data Source=christina\\sqlexpress;Initial 
                                 Catalog=cafe_inventory;User ID=sa;Password=tina;");
            con.Open();
            MySqlCommand command1 = new MySqlCommand("Select pname from inventory where
                                                             qt < 5", con);
            //Clear the datatable to prevent duplicate generation of data in gridview.
            p_table.Clear();
            MySqlDataAdapter m_da = new MySqlDataAdapter("Select * from inventory where
                                                              qt < 5", con);
            m_da.Fill(p_table);
            MySqlDataReader reader;
            reader = command1.ExecuteReader();
            StringBuilder productNames = new StringBuilder();
            while (reader.Read())
            {
                productNames.Append(reader["pname"].ToString() + Environment.NewLine);
            }
            
            con.Close();
            
            MessageBox.Show("There are products that needs restocking, 
                                                check to restock now." + productNames);
            // Display items in the ListView control
            for (int i = 0; i < p_table.Rows.Count; i++)
            {
                DataRow drow = p_table.Rows[i];
                // Only row that have not been deleted
                if (drow.RowState != DataRowState.Deleted)
                {
                    // Define the list items
                    //ListViewItem lvi = new ListViewItem(drow["bnum"].ToString());
                    ListViewItem lvi = new ListViewItem(drow["pnum"].ToString());
                    lvi.SubItems.Add(drow["pname"].ToString());
                    lvi.SubItems.Add(drow["descr"].ToString());
                    lvi.SubItems.Add(((DateTime)drow["dater"]).ToShortDateString());
                    //lvi.SubItems.Add(drow["exp"].ToString());
                    lvi.SubItems.Add(((DateTime)drow["exp"]).ToShortDateString());
                    lvi.SubItems.Add(drow["qt"].ToString());
                    lvi.SubItems.Add(drow["interval"].ToString());
                    // Add the list items to the ListView
                    listView4.Items.Add(lvi);
                }
            }
        }
