     try
    {
      //Your insert code here
    }
    catch (System.Data.SqlClient.SqlException sqlException)
    {
      System.Windows.Forms.MessageBox.Show(sqlException.Message);
    }
