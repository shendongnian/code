    public static void StaticButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Event from App.xaml.cs!");
    }
    // ten at any Page you can subscribe like this:
    myButton.Click += App.StaticButton_Click;
