    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      using (var progress = ObservableProgress<int>.CreateForUi(value => UpdateUi(value)))
      {
        await Task.Run(() => BackgroundOperation(progress));
      }
      ...
    }
    private static void UpdateUi(int progressUpdate)
    {
      TextBox.Text += progressUpdate.ToString();
    }
    private static void BackgroundOperation(IProgress<int> progress)
    {
      for (int i = 0; i < 10000; i++)
      {
        if (progress != null)
          progress.Update(i);
      }
    }
