    SqlConnection con = new SqlConnection(connectionString);
    SqlCommand com = new SqlCommand("ADD_PERSON_SP", con);
    com.Parameters.AddWithValue("@firstName", txtboxName.Text);
    com.Parameters.AddWithValue("@lastName", txtboxFamilyName.Text);
    com.Parameters.AddWithValue("@nationalID", txtboxNationalCode.Text);
    com.CommandType = CommandType.StoredProcedure;
    try
    {
        con.Open();
        com.ExecuteNonQuery();
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        if (con.State == ConnectionState.Open)
            con.Close();
    }
