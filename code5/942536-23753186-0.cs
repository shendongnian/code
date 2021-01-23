        /// <summary>
        /// Function to be executed when focus is on the password box.
        /// Basic function is to show the watermark in the password box.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ResetAuthenticationScreenAlignments();
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
