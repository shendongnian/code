    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        TextBoxOutput.Text = "calculating...";
        var result = await Task.Run(Calculate);
        TextBoxOutput.Text = result.ToString(CultureInfo.InvariantCulture);
    }
    private int Calculate()
    {
       Thread.Sleep(2000); //--similate working....
       return Environment.TickCount ^ 43;
    }
