     private void button1_Click(object sender, RoutedEventArgs e)
            {
                progressBar1.Visibility = Visibility.Visible;
                Thread.Sleep(5000);
                progressBar1.Visibility = Visibility.Hidden;
            }
