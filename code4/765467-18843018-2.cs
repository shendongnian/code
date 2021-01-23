            private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _listofValues.Add(1);
            _listofValues.Add(2);
            _listofValues.Add(3);
            
            var uc1 = new UserControl1(); // 
            uc1.DataContext = this;
            GameCanvas.Children.Add(uc1);
        }
