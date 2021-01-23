    private void newbutton()
        {
            // How many buttons do you want ?
            int NumOfButtons = 6;
            // X Location of each created button in the panel
            StackPanel stkpanel = new StackPanel();
            stkpanel.Orientation = Orientation.Horizontal;
            int loc = 20;
            for (int i = 1; i <= NumOfButtons; i++)
            {
                Button btn = new Button();
                {
                    btn.Name = "Btn-" + i.ToString();
                    btn.Height = 20;
                    btn.Width = 50;
                    btn.Foreground = new SolidColorBrush(Colors.White);
                    btn.Content = "btnnum" + i.ToString();
                    btn.Tag = i;
                    btn.Content = "Browse-" + i.ToString();
                    btn.Margin = new Thickness(5 + loc, 5, 5, 5);
                    btn.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
                }
                //Add Click event Handler for each created button
                btn.Click += btn_Click;
                loc += 20;
                // Add the created btn to grid
                stkpanel.Children.Add(btn);
            }
            grid.Children.Add(stkpanel);
        }
        void btn_Click(object sender, RoutedEventArgs e)
        {
           // throw new NotImplementedException();
        }
