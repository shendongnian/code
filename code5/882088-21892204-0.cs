            myMainPanel = new StackPanel();
            myMainPanel.Background = Brushes.Orange;
            button1 = new Button();
            button1.Name = "Button1";
            // Register button1's name with myMainPanel.
            myMainPanel.RegisterName(button1.Name, button1);
            button1.Content = "Button 1";
            button1.Click += new RoutedEventHandler(button1Clicked);
            myMainPanel.Children.Add(button1);
            button2 = new Button();
            button2.Name = "Button2";
            // Register button2's name with myMainPanel.
            myMainPanel.RegisterName(button2.Name, button2);
            button2.Content = "Button 2";
            button2.Click += new RoutedEventHandler(button2Clicked);
            myMainPanel.Children.Add(button2);
