    public MainWindow AppMainWindow { get; set; }
    private void button2_Click(object sender, RoutedEventArgs e)
    {
         Window1 w1 = new Window1();
         w1.Owner = this;
         w1.AppMainWindow = this;
         w1.ShowDialog();
    }
