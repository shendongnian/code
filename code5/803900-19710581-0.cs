        try
        {
           // your code....           
        }
        catch (Exception ex)
        {
            MessageBox.Show("My method failed, see inner excpetion",ex);
        }
        finally
        {
            connection.Close();
        }
        return numArray;
    }
