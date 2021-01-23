            var dr = e.Row.Item as yourItem
            // Other stuff....
            if (difference.Days <= 0)
            {
                e.Row.Background = new SolidColorBrush(Colors.ForestGreen);
                e.Row.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (difference.Days > 0 && difference.Days <= 60)
            {
                e.Row.Background = new SolidColorBrush(Colors.Orange);
                e.Row.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (difference.Days > 60)
            {
                e.Row.Background = new SolidColorBrush(Colors.Red);
                e.Row.Foreground = new SolidColorBrush(Colors.White);
            }
