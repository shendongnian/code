     private void StartButton_OnClick(object sender, RoutedEventArgs e) {
        if (_openFile != null && !String.IsNullOrEmpty(SaveToBox.Text)) {
            this.Dispatcher.BeginInvoke(new Action(delegate() {
                LocalVideoConverter lvc =  new LocalVideoConverter(_openFile.FileName, _from*1000, _to*1000,
                SaveToBox.Text, InterpolationMode.Low, new System.Drawing.Size(320, 240));
                lvc.StartConverting();
            }));
        } else
            MessageBox.Show("Choose video file and enter path for Gif");
    }
