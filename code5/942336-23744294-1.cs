    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Grid g = new Grid();
            g.HorizontalAlignment = HorizontalAlignment.Stretch;
            g.VerticalAlignment = VerticalAlignment.Center;
            g.Height = 68;
            g.RowDefinitions.Add(new RowDefinition());
            g.RowDefinitions.Add(new RowDefinition());
            Slider slider = new Slider();
            slider.TickPlacement = TickPlacement.Both;
            slider.Maximum = 2.0;
            slider.Minimum = -2.0;
            slider.TickFrequency = 0.5;
            slider.Height = 40;
            slider.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetRow(slider, 0);
            g.Children.Add(slider);
            TextBlock t1 = new TextBlock();
            t1.Height = 28;
            t1.HorizontalAlignment = HorizontalAlignment.Left;
            t1.Text = "-2";
            Grid.SetRow(t1, 1);
            g.Children.Add(t1);
            TextBlock t2 = new TextBlock();
            t2.Height = 28;
            t2.HorizontalAlignment = HorizontalAlignment.Center;
            t2.Text = "0";
            Grid.SetRow(t2, 1);
            g.Children.Add(t2);
            TextBlock t3 = new TextBlock();
            t3.Height = 28;
            t3.HorizontalAlignment = HorizontalAlignment.Right;
            t3.Text = "2";
            Grid.SetRow(t3, 1);
            g.Children.Add(t3);
            theGrid.Children.Add(g);
        }
