        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pwdBox.SecurePassword.Length == 0)
            {
                btn.IsEnabled = false;
            }
            else
            {
                btn.IsEnabled = true;
            }
        }
