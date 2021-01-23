    private void HandleMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var controlB = sender as ControlB;
            if (controlB != null && e.Delta > 0 && controlB.Scroll.VerticalOffset == 0)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                    {
                        RoutedEvent = UIElement.MouseWheelEvent,
                        Source = sender
                    };
                A.Scroll.RaiseEvent(eventArg);
            }
        }
