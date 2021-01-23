    SqlConnection connection = new SqlConnection("...");
    SqlCommand sql = new SqlCommand("...");
    List<Product> products = new List<Product>();
    //other instantiations
    
    try
    {
        connection.Open();
        sql.ExecuteScalar();
        //other operations
    }
    catch (Ecxeption ex)
    {
        //handle exception and show a message to the user
        MessageBox.Show(ex.Message);
    }
    finally
    {
        //this will always execute, even when an exception occurs
        //good for closing used resources
        connection.Close();
    }
