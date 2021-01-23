    void ControlBindings()
    {
        if (EqualToResults.IsChecked == true)
        {
            var cable = DataContext as NCable;
            Coordinates.ItemsSource = cable;
            var binding = new Binding("X");
            //REMOVE binding.Source = cable.Points;
            XColumn.Binding = binding;
        }
    }
