    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Slider slider = new Slider();
            slider.TickPlacement = TickPlacement.Both;
            slider.Maximum = 2.0;
            slider.Minimum = -2.0;
            slider.TickFrequency = 0.5;
            slider.Height = 40;
            slider.HorizontalAlignment = HorizontalAlignment.Stretch;
            theGrid.Children.Add(slider);
        }
