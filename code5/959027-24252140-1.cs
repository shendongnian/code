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
            control.IsTabStop = isTabStop;
        }
        /// <summary>
        /// Makes virtual keyboard disappear when user taps enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LooseFocusOnEnter(object sender, KeyRoutedEventArgs e) {
            if (e.Key == Windows.System.VirtualKey.Enter) {
                e.Handled = true; LoseFocus(sender);
            }
        }
