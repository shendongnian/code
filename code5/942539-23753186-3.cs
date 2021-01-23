        /// <summary>
        /// Function to be executed when focus is on the password box.
        /// Basic function is to show the watermark in the password box.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckPasswordWatermark();
        }
        /// <summary>
        /// Code checking the status of the password box and managing the watermark.
        /// </summary>
        private void CheckPasswordWatermark()
        {
            var passwordEmpty = string.IsNullOrEmpty(PwdBox.Password);
            PasswordWatermark.Opacity = passwordEmpty ? 100 : 0;
            PwdBox.Opacity = passwordEmpty ? 0 : 100;
        }
        /// <summary>
        /// Function to be executed when the password box loses focus.
        /// Basic fuction is to show the watermark in the password box.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordWatermark.Opacity = 0;
            PwdBox.Opacity = 100;
            if (!string.IsNullOrEmpty(PwdBox.Password))
            {
                PwdBox.SelectAll();
            }
        }
