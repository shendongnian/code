    public void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Event from App.xaml.cs!");
    }
    // then you can subscribe like this:
    myButton.Click += (App.Current as App).Button_Click;
