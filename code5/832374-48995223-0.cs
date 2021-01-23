            //Get datatable from db 
            DataTable dt = new DataTable();
            dt.TableName = "TABContacts";
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]);
            SqlCommand cmd = new SqlCommand("SELECT * FROM TABContacts", connection);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            StringBuilder builder = new StringBuilder();
         
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    string rowText = row.ItemArray[i].ToString();
                    if (rowText.Contains(","))
                    {
                        rowText = rowText.Replace(",", "/");
                    }
                    builder.Append(rowText + ",");
                }
                builder.Append(Environment.NewLine);
            }
            //Convert to Byte Array 
            byte[] data = Encoding.ASCII.GetBytes(builder.ToString());
