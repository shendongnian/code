    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Progress<int> progress = new Progress<int>(
            i => labelName.Content = i.ToString());
        await Task.Run(() => DoWork(progress));
    }
    private void DoWork(IProgress<int> progress)
    {
        for (int i = 0; i < 2000; i++)
        {
            //Do Stuff
            progress.Report(i);
        }
    }
