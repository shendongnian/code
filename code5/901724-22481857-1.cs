    private void Start_Click(object sender, RoutedEventArgs e)
    {
      proxy.On("ClientMethod", () => UpdateLabel());
      connection.Start().Wait();
    }
    private void UpdateLabel()
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action(UpdateLabel));
        return;
      }
      tb1.Text = "Hello";
    }
