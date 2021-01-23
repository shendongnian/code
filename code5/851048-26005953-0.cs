        void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            double h = -1;
            for (int row = 0; row < 3; row++)
                if (contentGrid.RowDefinitions[row].ActualHeight > h)
                    h = contentGrid.RowDefinitions[row].ActualHeight;
            for (int row = 0; row < 3; row++)
                if (contentGrid.RowDefinitions[row].ActualHeight < h)
                    contentGrid.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Star);
        }
