    private void Button_Click(object sender, RoutedEventArgs e)
    {
    TextBoxOutput.Text = "calculating...";
    Task.Factory.StartNew
        (() =>
        {
            var res = Calculate();
            Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    TextBoxOutput.Text = res.ToString(CultureInfo.InvariantCulture);
                }));
        });
    }
    private int Calculate()
    {
       Thread.Sleep(2000); //--similate working....
       return Environment.TickCount ^ 43;
    }
