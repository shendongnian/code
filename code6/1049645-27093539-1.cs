    public partial class MainWindow : Window
    {
      readonly otherClass _burnBabyBurn = new OtherClass();
      CancellationTokenSource _stopWorkingCts = new CancellationTokenSource();
      //A button method to start the long running method
      private async void Button_Click_3(object sender, RoutedEventArgs e)
      {
        var progress = new Progress<string>(data => UpdateWindow(data));
        try
        {
          await Task.Run(() => _burnBabyBurn.ExecuteLongProcedure(intParam1, intParam2, intParam3,
              _stopWorkingCts.Token, progress));
        }
        catch (OperationCanceledException)
        {
          // TODO: update the GUI to indicate the method was canceled.
        }
      }
      //A button Method to interrupt and stop the long running method
      private void StopButton_Click(object sender, RoutedEventArgs e)
      {
        _stopWorkingCts.Cancel();
      }
      //A method to allow the worker method to call back and update the gui
      void UpdateWindow(string message)
      {
        TextBox1.Text = message;
      }
    }
