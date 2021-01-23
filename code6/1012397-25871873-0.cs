        SolidColorBrush brush;
        Deployment.Current.Dispatcher.BeginInvoke(
            () => brush = new SolidColorBrush(
                Color.FromArgb(
                    255,
                    Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16)
            )));
        return brush;
    }
