        private void BtnMessageChannel_Click(object sender, RoutedEventArgs e)
        {
            if (!BtnMessageChannel.ContextMenu.IsOpen)
            {
                e.Handled = true;
    
                var mouseRightClickEvent = new MouseButtonEventArgs(Mouse.PrimaryDevice, Environment.TickCount, MouseButton.Right)
                {
                    RoutedEvent = Mouse.MouseUpEvent,
                    Source = sender,
                };
                InputManager.Current.ProcessInput(mouseRightClickEvent);
            }
        }
