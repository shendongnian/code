    private async void startTransmissionButton_Click(object sender, RoutedEventArgs e)
    {
        ComboBox.IsEnabled = false;
        Button1.IsEnabled = false;
        Button2.IsEnabled = false;
        Button3.IsEnabled = false;
    
        await
            Task.Factory.StartNew(
                () =>
                {
                    SerialPort com = new SerialPort("COM1");
    
                    com.Open();
                    c = (char)com.ReadChar();
                    com.Close();
                }
            );
    
        ComboBox.IsEnabled = true;
        Button1.IsEnabled = true;
        Button2.IsEnabled = true;
        Button3.IsEnabled = true;
    }
