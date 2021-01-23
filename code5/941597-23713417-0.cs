    private void one_Click(object sender, RoutedEventArgs e)
    {
        cts = new CancellationTokenSource();
        ct = cts.Token;
        string url = textBox.Text;//Read it in UI thread itself
        Task myTask = Task.Run(() => Save(url, ct));
    }
