      String query = "SP_PDF";
            SqlCommand cmd = new SqlCommand(query, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = Nombre.Text;
            cmd.Parameters.AddWithValue("@tel", SqlDbType.Int).Value = Telefono.Text;
            cmd.Parameters.AddWithValue("@dir", SqlDbType.VarChar).Value = Direccion.Text;
            cmd.Parameters.AddWithValue("@rfc", SqlDbType.Char).Value = RFC.Text;
            try
            {
                cnx.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>window.alert('¡Funciono!');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
