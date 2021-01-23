            StackPanel sp = new StackPanel();
            StackPanel btnSP = new StackPanel();
            btnSP.Orientation = Orientation.Horizontal;
            btnSP.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnSP.Children.Add(btn3);
            btnSP.Children.Add(btn4);
            sp.Children.Add(btnSP);
            StackPanelRight.Children.Add(sp);
