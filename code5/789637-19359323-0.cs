        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System && (e.SystemKey == Key.LeftAlt || e.SystemKey == Key.RightAlt))
            {
                e.Handled = true;
            }
        }
