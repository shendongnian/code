    try
    {
        SqlCommand comm = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories;",connection);
        connection.Open();
        SqlDataReader reader = comm.ExecuteReader();
        List<string> str = new List<string>();
        int i=0;
        while (reader.Read())
        {
            str.Add( reader.GetValue(0).ToString() );
        }
        reader.Close();
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        connection.Close();
    }
