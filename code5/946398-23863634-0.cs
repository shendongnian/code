     String query = "SP_PDF";
        SqlCommand cmd = new SqlCommand(query, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = Nombre.Text;
        cmd.Parameters.AddWithValue("@tel", SqlDbType.Int).Value = Telefono.Text;
        cmd.Parameters.AddWithValue("@dir", SqlDbType.VarChar).Value = Direccion.Text;
        cmd.Parameters.AddWithValue("@rfc", SqlDbType.Char).Value = RFC.Text;
    
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet set = new DataSet();
    
        try
        {
            cnx.Open();
            cmd.ExecuteNonQuery();
            adp.Fill(set);
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
