    private void yourTask()
    {
        // DO YOUR STUFF
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 10; i++ )
        {
            var thread = new Thread(this.yourTask);
            thread.IsBackground = true; // not really necessary here
            thread.Start();
        }
    }
