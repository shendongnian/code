    protected ICollection ddNames() {
            string selectSQL = "mysql stuff";
            string connString = "my string";
            SqlCommand cmd = new SqlCommand(selectSQL, conn);
            SqlDataReader reader;
		// Create a table to store data for the DropDownList control.
         DataTable dt = new DataTable();
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("NewItemTextField", typeof(String)));
         dt.Columns.Add(new DataColumn("NewItemValueField", typeof(String)));
		 dt.Rows.Add(CreateRow("Unassigned", "999999", dt));
            try  {
                conn.Open(); 
                reader = cmd.ExecuteReader();
                while ( reader.Read() )  {
                        // Populate the table with sample values.
						dt.Rows.Add(CreateRow(DataHelpers.GetUserFirstLastFromID(Convert.ToInt32(reader["someid"])), reader["someid"].ToString(), dt));
                }
                reader.Close();
            }   catch (Exception ex)   {
                 throw ex;
            }   finally    {
                    if (conn != null)  {
                        conn.Dispose();
                        conn.Close();
                    }
             }
        return dt;
        }
      DataRow CreateRow(String Text, String Value, DataTable dt)
      {
         // Create a DataRow using the DataTable defined in the 
         // CreateDataSource method.
         DataRow dr = dt.NewRow();
         // This DataRow contains the NewItemTextField and NewItemValueField 
         // fields, as defined in the CreateDataSource method. Set the 
         // fields with the appropriate value. Remember that column 0 
         // is defined as NewItemTextField, and column 1 is defined as 
         // NewItemValueField.
         dr[0] = Text;
         dr[1] = Value;
         return dr;
      }
