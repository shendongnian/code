    private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyPasswordBox.Password == String.Empty)
            {
                MessageBox.Show("Please enter a password");
            }
        }
