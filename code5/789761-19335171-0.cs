                WeekGrid.Children.Add(tmpTextBlock);
                Grid.SetRow(tmpTextBlock, 1);
                //add the border - these lines produce the problem
                Border border = new Border
                {
                    Child = tmpTextBlock,
                    Background = this.Resources["ApplicationPageBackgroundThemeBrush"] as SolidColorBrush,
                    BorderBrush = this.Resources["ApplicationForegroundThemeBrush"] as SolidColorBrush,
                    BorderThickness = new Thickness(1),
                };
