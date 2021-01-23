    try
    {
      //Whatever you want to try
    }
    catch(Exception e)
    {
      //Display error message
      MessageBox.Show(e.Message);
      //Close the application
      Application.Current.MainWindow.Close();
    }
