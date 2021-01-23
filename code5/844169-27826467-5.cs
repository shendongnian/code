         protected void ddl_selectedChanged(object sender, EventArgs e)
        {
            String strConnString = ConfigurationManager.ConnectionStrings["CONSTRING"].ConnectionString;
            String strQuery = "select description from table1 where Code = @Code";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Code", ddl.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtbdescription.Text = dr["description"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
