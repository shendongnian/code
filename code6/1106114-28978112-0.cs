    private async void Application_Startup(object sender, StartupEventArgs e)
    {
      HttpResponseMessage response = await TestWebAPIAsync();
      if (!response.IsSuccessStatusCode)
      {
        MessageBox.Show("The service is currently unavailable"); 
        Shutdown(1);
      }
      MainWindow main = new MainWindow();
      main.DataContext = ...
      main.Show();
    }
