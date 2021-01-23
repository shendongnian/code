        private async void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnRecord.IsEnabled = false;
                var fileName = Path.GetTempFileName() + ".wav";
                var recorder = new AudioRecorder(fileName);
                await recorder.RecordFixedTime(TimeSpan.FromSeconds(5));
                Process.Start(fileName);
            }
            finally
            {
                btnRecord.IsEnabled = true;
            }
        }
    
