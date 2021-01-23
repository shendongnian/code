        private void OnExpBtnClick(object sender, RoutedEventArgs e)
        {
            if (_exp)
            {
                _exp = false;
                MainGrid.ColumnDefinitions[0].Width = _origWidth;
            }
            else
            {
                _exp = true;
                _origWidth = MainGrid.ColumnDefinitions[0].Width;
                MainGrid.ColumnDefinitions[0].Width = new GridLength(0.0, GridUnitType.Pixel);
            }
         }
