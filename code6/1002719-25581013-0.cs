    private void install_btn_Click(object sender, RoutedEventArgs e)
    {
        inst_label.Visibility = Visibility.Visible;
        progress.Visibility = Visibility.Visible;
        install_btn.Visibility = Visibility.Hidden;
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        webClient.DownloadFile();
    }
