     private void btnQuery_Click(object sender, EventArgs e)
        {
            string strSql = this.txtQuery.Text;
            DataTable dt = new DataTable();
            String conStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\TestDB.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //with the call to strSQLSchema, we get the table involved in the query, to retrieve the fields and properties
                SqlCommand cmd = new SqlCommand(strSQLSchema(strSql), conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                try
                {
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.dgvColumns.DataSource = dt;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            //We must pass the sql query to preview
            string strSql = this.txtQuery.Text;
            SQLQueryDataPreview qp = new SQLQueryDataPreview(strSql);
            qp.Show();
        }
        #endregion
        private string strSQLSchema(string sqlQuery)
        {
            //we cut the "SELECT " start
            sqlQuery = sqlQuery.ToUpper();
            sqlQuery = sqlQuery.Substring(7);
            //we take all the fields until the FROM
            int myIndex = sqlQuery.IndexOf("FROM");
            sqlQuery = sqlQuery.Substring(0, myIndex);
            sqlQuery = sqlQuery.Trim();
            sqlQuery = sqlQuery.Replace(" ", string.Empty);
            sqlQuery = sqlQuery.Replace("\r\n", string.Empty);
            //Here we add all fields to a list... so far, "*" is not allowed, and all fields should be written [Table].[Name]
            string[] myFields = sqlQuery.Split(new char[] {' ', ','});
            
            List <string> myTables = new List<string>();
            //We will use this WHERE to find the fields in the SCHEMA. This WHERE first sentence helps to construct a valid where
            //and avoid problems with the 'OR' clause in each loop.
            string myWhere = "TABLE_NAME + '.' + COLUMN_NAME = ''";
            for (int i = 0; i < myFields.Count(); i++)
            {
                //here we take the table prefix and add it to an array
                int tableIndex = myFields[i].IndexOf(".");
                if (tableIndex != -1)
                {
                    myTables.Add(myFields[i].Substring(0, tableIndex));
                    myWhere += "OR (TABLE_NAME + '.' + COLUMN_NAME = '" + myFields[i] + "')";
                }
                else
                {
                    if (myFields[i].Substring(0, tableIndex) == "*")
                    {
                        // we must add all fields in a table we don't have!
                    }
                }
            }
            //this is a List where we keep the tables derivated from names. We just copy the list generated before with a DISTINCT to eliminate duplicates.
            myTables = myTables.Distinct().ToList();
            string schema = "SELECT Table_Name, Column_Name, Data_Type FROM INFORMATION_SCHEMA.COLUMNS WHERE " + myWhere;
            return schema;
        }
    }
