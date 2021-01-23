    SelectReader = selectCommand.ExecuteReader();
    while (SelectReader.Read())
    {
              Int64 BLOCK = Convert.ToInt64(SelectReader["BLOCK"]);
              if (BLOCK == false)
              {
                  con.Open();
                  SqlCommand cmd = con.CreateCommand();
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "SearchUser";
                  cmd.Parameters.AddWithValue("@NAME", TextBox4.Text.Trim());
                  SqlDataAdapter da = new SqlDataAdapter(cmd);
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  GridView1.DataBind();
                  con.Close();
              }
              else
              {
                  Response.Write("Error");
              }
          }
