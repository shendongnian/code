        Border b = new Border();
        Grid.SetColumn(b, 0);
        Grid.SetColumnSpan(b, 4);
        Grid.SetRowSpan(b, 4);
        b.CornerRadius = new CornerRadius(1);
        b.Background = new SolidColorBrush(Colors.Red);
        // Then add your border to the grid
        m_Board.Children.Add(b);
