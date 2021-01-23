        try
        {
          //.......
        }
        catch (Exception err)
        {
             string error = err.ToString();
        }
        finally
        {
             this.DBcon.Close();
        }
