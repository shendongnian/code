            double x = rect.Margin.Left;
            double y = rect.Margin.Top;
            if (e.Key == Key.D)
            {
                rect.Margin = new Thickness(x+5, y, 0, 0);
            }
            else if (e.Key == Key.A)
            {
                rect.Margin = new Thickness(x-5, y, 0, 0);
            }
            Thread.Sleep(100);
        }
