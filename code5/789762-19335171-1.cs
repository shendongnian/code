             Border border = new Border
                {
                    Child = tmpTextBlock,
                    Background = this.Resources["ApplicationPageBackgroundThemeBrush"] as SolidColorBrush,
                    BorderBrush = this.Resources["ApplicationForegroundThemeBrush"] as SolidColorBrush,
                    BorderThickness = new Thickness(1),
                };
                WeekGrid.Children.Add(border);
                Grid.SetRow(border, 1);
