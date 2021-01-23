        private void ChannelBtnItemContainerLoaded(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            element.Loaded -= ChannelBtnItemContainerLoaded;
            element.Dispatcher.BeginInvoke((Action)(() =>
            {
                ToggleButton tgbChannelName = FindChild<ToggleButton>(element, "tgbChannelName");
                if (tgbChannelName != null) //Sometimes It equal null
                {
                    //Do something
                }
                else
                {
                }
            }), DispatcherPriority.Background);
        }
