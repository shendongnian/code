     MySqlConnection conn = new MySqlConnection(connStr);
          string sql = "SELECT * FROM country";
          countries = new MySqlDataAdapter(sql, conn);
          MySqlCommandBuilder cb = new MySqlCommandBuilder(countries);
          ds = new DataSet();
          countries.Fill(ds, "Country");
          DataTable dt;
          for (int i = 0; i <ds.Tables.Count; i++)//traverse by each table in dataset
          {
               dt = ds.Tables[i];
               for (int j = 0; j < dt.Rows.Count; j++)//traverse by row
               {
                    Response.Write("Current Row--> "+j.ToString()+Environment.NewLine);
                    object[] ob = dt.Rows[j].ItemArray; // get array of column from present row
                    for (int k = 0; k <= ob.GetUpperBound(0); k++)
                    {
                         Response.Write("Current column Number--> "+k.ToString()+" Value = "+ob[k].ToString()+Environment.NewLine);
                    }
               }
          }
