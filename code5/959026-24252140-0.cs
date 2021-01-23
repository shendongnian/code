        /// <summary>
        /// Makes virtual keyboard disappear
        /// </summary>
        /// <param name="sender"></param>
        private void LoseFocus(object sender) {
            var control = sender as Control;
            var isTabStop = control.IsTabStop;
            control.IsTabStop = false;
            control.IsEnabled = false;
            control.IsEnabled = true;
            // this.Focus(FocusState.Programmatic); // works without it as well!
            control.IsTabStop = isTabStop;
        }
        private void NameBox_KeyDown(object sender, KeyRoutedEventArgs e) {
            if (e.Key == Windows.System.VirtualKey.Enter) {
                e.Handled = true;
                LoseFocus(sender);
            }
        }
