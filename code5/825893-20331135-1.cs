                foreach(var item in ContactPersons)
                {
                    TextBlock tb = new TextBlock();
                    tb.Margin = new Thickness(0,y_coordinateStart ,0,0);
                    tb.Foreground = new SolidColorBrush(Colors.Green);
                    tb.Visibility = Visibility.Visible;
                    tb.Height = 30;
                    tb.Width = 300;
                    y_coordinateStart += 35;
                    tb.Text = item.firsName;
                    MainPanel.Children.Add(tb);
                }
