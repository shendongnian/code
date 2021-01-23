        private bool ClearTextBox = false;
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbSender = (TextBox)sender;
            if (tbSender.Text == "Name" ||
                tbSender.Text == "E-mail address" ||
                tbSender.Text == "Confirm e-mail" ||
                tbSender.Text == "Mobile number" ||
                tbSender.Text == "Password")
            {
                tbSender.Foreground = new SolidColorBrush(Colors.LightGray);
                tbSender.Select(0, 0);
                tbSender.SelectionStart = 0;
                ClearTextBox = true;
            }
            else
            {
                tbSender.Select(tbSender.Text.Length, 0);
            }
        }
        
        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox tbSender = (TextBox)sender;
            if (ClearTextBox)
            {
                tbSender.Foreground = new SolidColorBrush(Colors.Black);
                tbSender.Text = tbSender.Text.Substring(0, 1);
                tbSender.SelectionStart = 1;
                ClearTextBox = false;
            }
        }
