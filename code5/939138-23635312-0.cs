    try
    {
         //Check if it is not already open
         DataContext.Connection.Open();
    }
    catch (SqlException sEx)
    {
        //Log sEx
    }
    catch (Exception ex)
    {
        // log ex
    }
    finally
    {
        if (DataContext.Connection != null && DataContext.Connection.State == ConnectionState.Open)
        {
            DataContext.Connection.Close();
        }
    }
