     private void NoButton_Click(object sender, RoutedEventArgs e)
            {
                ShowData(); // Invoke & select from database again.
                // NoButton Clicked! Let's hide our InputBox.
                InputBox.Visibility = System.Windows.Visibility.Collapsed;
            }
