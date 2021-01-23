            var stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(stackPanel, 2);
            Grid.SetColumn(stackPanel, 3);
            this.grid1.Children.Add(stackPanel);
            var sliders = new List<Ellipse>();
            double leftMargin = 0;
            double rightMargin = 0;
            int diametrOfCircles = 50;
            double widthOfCanvas = System.Windows.SystemParameters.PrimaryScreenWidth;
            int placeBtwCircles = 30;
            double sum = 0;
            leftMargin = sum / 2;
            rightMargin = sum / 2;
            for (int i = 0; i < GetNumberOfImages(); i++)
            {
                sliders.Add(new Ellipse());
                sliders[i].Stroke = System.Windows.Media.Brushes.Black;
                sliders[i].Fill = System.Windows.Media.Brushes.White;
                sliders[i].Width = 20;
                sliders[i].Height = 20;
                sliders[i].Margin = new Thickness(5);
                stackPanel.Children.Add(sliders[i]);
                sliders[0].Opacity = 0.9;
            }
