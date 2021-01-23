        public EventHandler<RoutedEventArgs> ButtonAction;
        private void BtnClick_DoClick(object sender, RoutedEventArgs e)
        {
            if (ButtonAction != null) ButtonAction(sender, e);
        }
