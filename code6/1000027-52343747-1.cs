        private void aWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.FullPrimaryScreenHeight;
            MaxWidth = SystemParameters.FullPrimaryScreenWidth;
            Width = SystemParameters.FullPrimaryScreenWidth;
            Height = SystemParameters.FullPrimaryScreenHeight;
            WindowState = WindowState.Maximized;
            ResizeMode = ResizeMode.NoResize;
            Left = 0;
            Top = 0;
            Topmost = true;
            ShowInTaskbar = false;
            //throw new NotImplementedException();
        }
