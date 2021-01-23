    private void OnChanged(object source, FileSystemEventArgs e) {
        Application.Current.Dispatcher.BeginInvoke(new Action(() => DoSomethingOnUiThread()));
    }
    private void DoSomethingOnUiThread() {
        Test_Button.Width = 500;
    }
